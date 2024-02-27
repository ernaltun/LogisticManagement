using LogisticManagement.Entity;

namespace LogisticManagement.Data.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(int id);
        void Save();

    }
}
