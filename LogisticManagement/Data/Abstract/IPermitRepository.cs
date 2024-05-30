using LogisticManagement.Entity;

namespace LogisticManagement.Data.Abstract
{
	public interface IPermitRepository
	{
        IQueryable<Permit> Permits { get; }
        IEnumerable<Permit> GetAll();
		Permit GetById(int id);
		List<Permit> GetByUser(int userId);
		void Insert(Permit permit);
		void Update(Permit permit);
		void Delete(int id);
		void Save();
	}
}
