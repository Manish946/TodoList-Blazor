﻿namespace TodoList_Blazor.Domain
{
	public class TodoList
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int UserID { get; set; }
		public User User { get; set; }
	}
}