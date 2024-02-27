using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace LogisticManagement.Entity
{
	public class User
	{
        [Key]
		public int UserId { get; set; }
		public string? UserName { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
		public string? Image { get; set; }
		public List<Ticket> Tickets { get; set; } = new List<Ticket>();
		public List<Comment> Comments { get; set; } = new List<Comment>();
	}
}
