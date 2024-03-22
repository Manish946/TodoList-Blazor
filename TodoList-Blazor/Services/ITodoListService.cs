using TodoList_Blazor.Domain;

namespace TodoList_Blazor.Services
{
	public interface ITodoListService
	{
		List<TodoList> getUserTodoLists(int userId);

		void createTodoList(TodoList item);

		void deleteTodoList(TodoList item);
		void updateTodoList(TodoList item);
		void clearAllTodoList();

    }
}
