using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LogisticManagement.Entity
{
	public class Ticket
	{
        [Key]
        public int TicketId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime? PublishedOn { get; set; }
        public bool? IsActive { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
