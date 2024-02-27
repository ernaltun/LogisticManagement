using System.ComponentModel.DataAnnotations;

namespace LogisticManagement.Entity
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceType { get; set;}
        public string ETTN { get; set; }
        public decimal Amount { get; set; }
        public int CusomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
