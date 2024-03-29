using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using TodoList_Blazor.Components;
using TodoList_Blazor.Components.Account;
using TodoList_Blazor.Data;
using TodoList_Blazor.HelperServies;
using TodoList_Blazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBlazorBootstrap();
// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITodoListService, TodoListService>();
builder.Services.AddScoped<ICprService, CprService>();
builder.Services.AddScoped<IPrivateKeyStorageService, PrivateKeyStorageService>();
builder.Services.AddSingleton<RoleHandler>();
builder.Services.AddSingleton<SymmetricHandler>();
builder.Services.AddScoped<AsymmetricHandler>(serviceProvider =>
{
    var privateKeyStorageService = serviceProvider.GetRequiredService<IPrivateKeyStorageService>();
    return new AsymmetricHandler(privateKeyStorageService);
});

builder.Services.AddAuthentication(options =>
	{
		options.DefaultScheme = IdentityConstants.ApplicationScheme;
		options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
	})
	.AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<DataContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
	// Enable Identity Roles
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddSignInManager()
	.AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
	// Policy for require Authenticated User
	options.AddPolicy("AuthenticatedUser", policy =>
	{
		policy.RequireAuthenticatedUser();
	});

	// Policy for Require Admin Role
	options.AddPolicy("RequireAdminRole", policy =>
	{
		policy.RequireRole("Admin");
	});

    options.AddPolicy("RequireMemberRole", policy =>
    {
        policy.RequireRole("Member");
    });
});

builder.Services.Configure<IdentityOptions>(options =>
{
	// Default Password settings.
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 6;
	options.Password.RequiredUniqueChars = 1;
});

// Get User Folder
string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
userFolder = Path.Combine(userFolder, ".aspnet");
userFolder = Path.Combine(userFolder, "https");
userFolder = Path.Combine(userFolder, "h5test.pfx");
builder.Configuration.GetSection("Kestrel:Endpoints:Https:Certificate:Path").Value = userFolder;
string KestrelCertPassword = builder.Configuration.GetValue<string>("KestrelCertPassword");
builder.Configuration.GetSection("Kestrel:Endpoints:Https:Certificate:password").Value = KestrelCertPassword;

builder.WebHost.UseKestrel((context, serverOptions) =>
{
	serverOptions.Configure(context.Configuration.GetSection("Kestrel"))
		.Endpoint("HTTPS", listenOptions =>
		{
			listenOptions.HttpsOptions.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
		});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
