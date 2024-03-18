using TodoList_Blazor.Data;

namespace TodoList_Blazor.Domain
{
	public class User
	{
		public int Id { get; set; }
		public string userName { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
}
