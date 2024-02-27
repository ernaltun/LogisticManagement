using System.ComponentModel.DataAnnotations;

namespace LogisticManagement.Entity
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
