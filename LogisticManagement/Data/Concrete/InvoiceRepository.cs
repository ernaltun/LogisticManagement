using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete.Context;
using LogisticManagement.Entity;

namespace LogisticManagement.Data.Concrete
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _context;
        public InvoiceRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

		public IQueryable<Invoice> Invoices => _context.Invoices;

		public void Delete(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Invoice> GetAll()
        {
            var invoices = _context.Invoices;
            return invoices;
        }

        public Invoice GetById(int id)
        {
            var invoice = _context.Invoices.Find(id);
            return invoice;
        }

        public void Insert(Invoice invoice)
        {
            _context.Add(invoice);
            _context.SaveChanges();
        }

		public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Invoice invoice)
        {
            _context.Update(invoice);
            _context.SaveChanges();
        }


	}
}
