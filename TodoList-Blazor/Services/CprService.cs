using TodoList_Blazor.Data;
using TodoList_Blazor.Domain;

namespace TodoList_Blazor.Services
{
	public class CprService : ICprService
	{
		private readonly DataContext _dataContext;

		public CprService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public void createCpr(string cpr, User user)
		{
			Cpr newCpr = new Cpr();
			newCpr.CprNr = cpr;
			newCpr.User = user;
			_dataContext.Cpr.Add(newCpr);
			_dataContext.SaveChanges();
		}

		public Cpr getCpr(User user)
		{
			var userCpr = _dataContext.Cpr.Where(cpr => cpr.User == user).FirstOrDefault();
			return userCpr;
		}
	}
}
