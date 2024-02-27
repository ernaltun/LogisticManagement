using System.ComponentModel.DataAnnotations;

namespace LogisticManagement.Entity
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public decimal Price { get; set; }
    }
}
