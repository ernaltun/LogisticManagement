using LogisticManagement.Entity;

namespace LogisticManagement.Data.Abstract
{
	public interface IUserRepository
	{
		IQueryable<User> Users { get; }
		void CreateUser(User User);
		User GetUserById(int id);
        User GetUserByUserName(string userName);
		void Update(User user);
	}
}
