using System.ComponentModel.DataAnnotations;

namespace LogisticManagement.Entity
{
    public class Customer
    {
        [Key]
        public int CusomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxNo { get; set; }
        public decimal Balance { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
