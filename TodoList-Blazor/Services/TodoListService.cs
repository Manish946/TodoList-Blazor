using TodoList_Blazor.Data;
using TodoList_Blazor.Domain;

namespace TodoList_Blazor.Services
{
	public class TodoListService : ITodoListService
	{
		private readonly DataContext _dataContext;

		public TodoListService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public List<TodoList> getUserTodoLists(int userId)
		{
			return _dataContext.Todolist.Where(todolist => todolist.UserID == userId).ToList();
		}

		public void createTodoList(TodoList item)
		{
			_dataContext.Todolist.Add(item);
			_dataContext.SaveChanges();
		}

		public void deleteTodoList(TodoList item)
		{
			_dataContext.Todolist.Remove(item);
			_dataContext.SaveChanges();
		}
	}
}
