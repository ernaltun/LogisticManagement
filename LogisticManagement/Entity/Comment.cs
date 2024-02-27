using System.ComponentModel.DataAnnotations;

namespace LogisticManagement.Entity
{
	public class Comment
	{
		[Key]
        public int CommentId { get; set; }
        public string? Text { get; set; }
        public DateTime? PublishedOn { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }  = null!;
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; } = null!;
	}
}
