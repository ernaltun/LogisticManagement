using LogisticManagement.Entity;

namespace LogisticManagement.Data.Abstract
{
    public interface IInvoiceRepository
	{
		IQueryable<Invoice> Invoices { get; }
		IEnumerable<Invoice> GetAll();
		Invoice GetById(int id);
        void Insert(Invoice invoice);
        void Update(Invoice invoice);
        void Delete(int id);
        void Save();

    }
}
