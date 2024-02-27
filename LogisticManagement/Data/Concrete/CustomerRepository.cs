using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete.Context;
using LogisticManagement.Entity;

namespace LogisticManagement.Data.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _context.Customers;
            return customers;
        }

        public Customer GetById(int id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }

        public void Insert(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
        }
    }
}
