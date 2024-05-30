using System.Runtime.InteropServices;
using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete.Context;
using LogisticManagement.Entity;
using Microsoft.Identity.Client;

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

        public User GetUserById(int id)
        {
            var user = _context.Users.Find(id);
			return user;
        }

        public User GetUserByUserName(string userName)
        {
            var user = _context.Users.Find(userName);
            return user;
        }

		public void Update(User user)
		{
			_context.Update(user);
			
			_context.SaveChanges();
		}
	}
}
