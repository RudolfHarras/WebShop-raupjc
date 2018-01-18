using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop_raupjc.Data;

namespace WebShop_raupjc.Models
{

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }


		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}