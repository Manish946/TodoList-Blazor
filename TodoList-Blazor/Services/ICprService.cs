using TodoList_Blazor.Domain;

namespace TodoList_Blazor.Services
{
	public interface ICprService
	{
		void createCpr(string cpr, User user);
		Cpr getCpr(User user);
	}
}
