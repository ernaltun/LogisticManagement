using System.Runtime.CompilerServices;
using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete;
using LogisticManagement.Entity;
using LogisticManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LogisticManagement.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        public InvoiceController(IInvoiceRepository invoiceRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _invoiceRepository = invoiceRepository;
            _customerRepository = customerRepository;

        }
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> Index()
        {
            return View(await _invoiceRepository.Invoices.Include(x => x.Customer).ToListAsync());
        }
		[Authorize(Roles = "admin")]
		public IActionResult AddInvoice()
        {
            ViewBag.Customers = _customerRepository.GetAll();
            var productv = _productRepository.GetAll();

            ViewBag.Products = new SelectList(productv, "ProductId", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddInvoice(InvoiceViewModel invoiceViewModel)
        {
            var customer = _customerRepository.GetById(invoiceViewModel.Customer.CusomerId);
            var products = new List<Product>();
            decimal totalAmount = 0; 

            foreach (var productId in invoiceViewModel.SelectedProducts)
            {
                var product = _productRepository.GetById(productId);
                products.Add(product);
                totalAmount += product.Price; 
            }

            var invoice = new Invoice
            {
                InvoiceNo = invoiceViewModel.Invoice.InvoiceNo,
                InvoiceType = invoiceViewModel.Invoice.InvoiceType,
                ETTN = invoiceViewModel.Invoice.ETTN,
                Amount = totalAmount,
                CusomerId = invoiceViewModel.Customer.CusomerId,
                Customer = customer,
                Products = products
            };

            var balanceRemaining = customer.Balance - invoice.Amount;
            customer.Balance = balanceRemaining;
            _customerRepository.Update(customer);
            _invoiceRepository.Insert(invoice);

            return RedirectToAction(nameof(Index));


            ViewBag.Customers = _customerRepository.GetAll();
            ViewBag.Products = _productRepository.GetAll(); // Ürünleri ViewBag üzerinden alın
            return View(invoiceViewModel);
        }
		[Authorize(Roles = "admin")]
		[HttpGet]
        public async Task<IActionResult> InvoiceDetails(int id)
        {
            var invoice = await _invoiceRepository.Invoices
            .Include(x => x.Customer)
            .Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.InvoiceId == id);

            var invoiceViewModel = new InvoiceViewModel
            {
                Invoice = invoice,
                Customer = invoice.Customer,
                Products = invoice.Products
            };

            return View(invoiceViewModel);
        }
    }
}
