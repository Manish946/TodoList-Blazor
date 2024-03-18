using TodoList_Blazor.Data;
using Microsoft.AspNetCore.Identity;

namespace TodoList_Blazor.Services
{
	public class RoleHandler
	{
		public async Task CreateUserRole(string userEmail, string role, IServiceProvider serviceProvider)
		{
			// Call Manager
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			// Create Role in role table
			var userRoleCheck = await roleManager.RoleExistsAsync(role);

			// Create Role in the role table
			if (!userRoleCheck)
			{
				await roleManager.CreateAsync(new IdentityRole(role));
			}
			// Add user to the role

			ApplicationUser applicationUser = await userManager.FindByEmailAsync(userEmail);
			await userManager.AddToRoleAsync(applicationUser, role);
		}
	}
}