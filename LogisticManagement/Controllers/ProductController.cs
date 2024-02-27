using LogisticManagement.Data.Abstract;
using LogisticManagement.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var customers = _productRepository.GetAll().ToList();
            return View(customers);
        }

        [Authorize]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product customer)
        {
            _productRepository.Insert(customer);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult ProductDetails(int id)
        {
            var customerDetail = _productRepository.GetById(id);
            return View(customerDetail);
        }
        [HttpPost]
        public IActionResult ProductEdit(Product customer)
        {
            _productRepository.Update(customer);
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
