using LogisticManagement.Entity;
using Microsoft.Extensions.Hosting;

namespace LogisticManagement.Data.Abstract
{
	public interface ITicketRepository
	{
        IQueryable<Ticket> Tickets { get; }
        IEnumerable<Ticket> GetAll();
		Ticket GetById(int id);
		List<Ticket> GetByUser(int userId);
		void Insert(Ticket ticket);
		void Update(Ticket ticket);
		void Delete(int id);
		void Save();
	}
}
