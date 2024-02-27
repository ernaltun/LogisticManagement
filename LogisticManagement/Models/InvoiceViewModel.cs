using System.ComponentModel.DataAnnotations;
using LogisticManagement.Entity;

namespace LogisticManagement.Models
{
    public class InvoiceViewModel
    {
        public Invoice Invoice { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public List<int> SelectedProducts { get; set; }
    }
}
