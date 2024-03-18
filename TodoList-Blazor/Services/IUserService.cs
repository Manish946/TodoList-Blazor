using TodoList_Blazor.Data;
using TodoList_Blazor.Domain;

namespace TodoList_Blazor.Services
{
	public interface IUserService
	{
		void createUser(ApplicationUser applicationUser, string fullName);

		void updateUser();

		User getUserByUserName(string userName); 
	}
}
