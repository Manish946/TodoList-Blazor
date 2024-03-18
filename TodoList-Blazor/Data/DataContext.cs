using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using TodoList_Blazor.Domain;

namespace TodoList_Blazor.Data
{
    public class DataContext: DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{

	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ToDoListDB;Trusted_Connection=True;MultipleActiveResultSets=true");
	}

	public DbSet<TodoList> Todolists { get; set; }
	public DbSet<Cpr> Cprs { get; set; }
	public DbSet<User> Users { get; set; }
	}
}
