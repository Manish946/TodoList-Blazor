using TodoList_Blazor.Data;
using TodoList_Blazor.Domain;

namespace TodoList_Blazor.Services
{
	public class UserService : IUserService
	{
		private readonly DataContext _dataContext;

		public UserService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public void createUser(ApplicationUser applicationUser, string userName)
		{
			User user= new User();
			user.ApplicationUser = applicationUser;
			user.userName = userName;
			_dataContext.User.Add(user);
			_dataContext.SaveChanges();
		}

        public User getUserByUserName(string userName)
        {
			var user = _dataContext.User.FirstOrDefault(user => user.userName == userName);
			return user;
        }

        public void updateUser()
		{
			throw new NotImplementedException();
		}
	}
}
