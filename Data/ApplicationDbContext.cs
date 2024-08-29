using Microsoft.EntityFrameworkCore;
using ECommercePlatform.Models;

namespace ECommercePlatform.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartItem> CartItems { get; set; } 
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}
