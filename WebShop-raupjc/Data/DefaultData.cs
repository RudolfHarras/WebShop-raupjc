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


			context.Database.EnsureCreated();
			if (context.Products.Any()) return;

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
			context.SaveChanges();

			if (context.Products.Any())
			{
				context.Orders.AddRange(
					new Order
					{
						Country = "Perostan",
						Zip = "123456",
						City = "Perograd",
						Address = "Perija Perijevog 1",
						GiftWrap = true,
						Name = "Pero"
					}
				);
				context.SaveChanges();
			}
		}
	}
}