using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebShop_raupjc.Models
{
	// Defaultni artikli koji se generiraju ako je baza podataka prazna
	public static class DefaultData
	{

		public static void EnsurePopulated(IApplicationBuilder app)
		{
			ApplicationDbContext context = app.ApplicationServices
				.GetRequiredService<ApplicationDbContext>();

			AppIdentityDbContext userContext = app.ApplicationServices
				.GetRequiredService<AppIdentityDbContext>();

			userContext.Database.EnsureCreated();
			context.Database.EnsureCreated();


			if (context.Products.Any() && userContext.Users.Any()) return;

			if (!context.Products.Any()) {
					context.Products.AddRange(
					new Product
					{
						Name = "26g Phil The Power Taylor Target",
						Description = "Strelice za pikado koje koristi Phil Taylor",
						Category = "Strelice",
						Price = 500
					},

					new Product
					{
						Name = "Unicorn Eclipse Pro HD2",
						Description = "Meta za pikado koja se koristi u PDC turnirima",
						Category = "Mete",
						Price = 400
					}
				);
				
			}
			context.SaveChanges();
			/*
			if (!userContext.Users.Any()) {
				userContext.Users.AddRange(
					new ApplicationUser("pero@pero.hr")
				);
			}

			userContext.SaveChanges();
			*/	
		}
	}
}