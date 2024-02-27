using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete.Context;
using LogisticManagement.Entity;

namespace LogisticManagement.Data.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var customers = _context.Products;
            return customers;
        }

        public Product GetById(int id)
        {
            var product = _context.Products.Find(id);
            return product;
        }

        public void Insert(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}
