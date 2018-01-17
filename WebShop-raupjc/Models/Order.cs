using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebShop_raupjc.Models
{

	public class Order
	{

		[BindNever]
		public int OrderId { get; set; }
		[BindNever]
		public ICollection<CartLine> Lines { get; set; }

		[BindNever]
		public bool Shipped { get; set; }

		[Required(ErrorMessage = "Ime je obavezno")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Adresa je obavezna")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Grad je obavezan")]
		public string City { get; set; }

		[Required(ErrorMessage = "Poštanski broj je obavezan")]
		public string Zip { get; set; }

		[Required(ErrorMessage = "Država je obavezna")]
		public string Country { get; set; }

		public bool GiftWrap { get; set; }
	}
}