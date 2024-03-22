namespace TodoList_Blazor.Domain
{
	public class Cpr
	{
		public int Id { get; set; }
		public string CprNr { get; set; }

		public User User { get; set; }
	}
}
