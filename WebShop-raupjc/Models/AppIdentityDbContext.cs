using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop_raupjc.Data;

namespace WebShop_raupjc.Models
{

	public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
	{

		public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
			: base(options) { }
	}
}