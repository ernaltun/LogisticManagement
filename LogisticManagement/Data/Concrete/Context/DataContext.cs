using LogisticManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace LogisticManagement.Data.Concrete.Context
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext>options): base(options)
        {
            
        }
		public DbSet<Comment> Comments {get; set;}
		public DbSet<User> Users { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Permit> Permits { get; set; }
	}
}
