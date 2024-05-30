using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete.Context;
using LogisticManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace LogisticManagement.Data.Concrete
{
	public class PermitRepository : IPermitRepository
	{
		private readonly DataContext _context;
		public PermitRepository(DataContext context)
		{
			_context = context;
		}

        public IQueryable<Permit> Permits => _context.Permits;

        public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Permit> GetAll()
		{
			var permits = _context.Permits;
			return permits;
		}

		public Permit GetById(int id)
		{
			var permit = _context.Permits
						.Include(p => p.User) // User ilişkisini include et
						.FirstOrDefault(p => p.PermitId == id);
			return permit;
		}

		public List<Permit> GetByUser(int userId)
		{
			var permits = _context.Permits
						.Include(p => p.User)
						.Where(p => p.UserId == userId)
						.ToList();
			return permits;
		}

		public void Insert(Permit permit)
		{
			_context.Add(permit);
			_context.SaveChanges();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public void Update(Permit permit)
		{
			_context.Update(permit);
			_context.SaveChanges();
		}
	}
}
