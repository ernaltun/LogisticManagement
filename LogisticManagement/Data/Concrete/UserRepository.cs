using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete.Context;
using LogisticManagement.Entity;

namespace LogisticManagement.Data.Concrete
{
	public class UserRepository : IUserRepository
	{
		private DataContext _context;
		public UserRepository(DataContext context)
		{
			_context = context;
		}
		public IQueryable<User> Users => _context.Users;

		public void CreateUser(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}
	}
}
