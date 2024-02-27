using LogisticManagement.Entity;

namespace LogisticManagement.Data.Abstract
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        void Save();

    }
}
