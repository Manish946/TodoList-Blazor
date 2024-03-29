﻿using TodoList_Blazor.Data;
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

		public void updateTodoList(TodoList item)
		{
			var existedTodoList = _dataContext.Todolist.Where(todoList => todoList.Id == item.Id).FirstOrDefault();
			if (existedTodoList != null)
			{
				_dataContext.Todolist.Update(item);
				_dataContext.SaveChanges();
			}
		}

        public void clearAllTodoList()
        {
            // clear database table
            _dataContext.Todolist.RemoveRange(_dataContext.Todolist);
            _dataContext.SaveChanges();
        }
    }
}
