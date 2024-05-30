using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete.Context;
using LogisticManagement.Entity;

namespace LogisticManagement.Data.Concrete
{
	public class TicketRepository : ITicketRepository
	{
		private readonly DataContext _context;
        public TicketRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public IQueryable<Ticket> Tickets => _context.Tickets;
        public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Ticket> GetAll()
		{
			var tickets = _context.Tickets;
			return tickets;
		}

		public Ticket GetById(int id)
		{
			var ticket = _context.Tickets.Find(id);
			return ticket;
		}

        public List<Ticket> GetByUser(int userId)
        {
            var tickets = _context.Tickets.Where(ticket => ticket.UserId == userId).ToList();
            return tickets;
        }

        public void Insert(Ticket ticket)
		{
			_context.Tickets.Add(ticket);
			_context.SaveChanges();
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(Ticket ticket)
		{
			throw new NotImplementedException();
		}
        
    }
}
