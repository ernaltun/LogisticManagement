using LogisticManagement.Data.Abstract;
using LogisticManagement.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var customers = _customerRepository.GetAll().ToList();
            return View(customers);
        }

        [Authorize]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerRepository.Insert(customer);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult CustomerDetails(int id)
        {
            var customerDetail = _customerRepository.GetById(id);
            return View(customerDetail);
        }
        [HttpPost]
        public IActionResult CustomerEdit(Customer customer)
        {
            _customerRepository.Update(customer);
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
