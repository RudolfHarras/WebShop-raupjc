using System.ComponentModel.DataAnnotations;

namespace WebShop_raupjc.Models
{

	public class Product
	{

		public int ProductId { get; set; }

		[Required(ErrorMessage = "Ime proizvoda je obavezno")]
		[Display(Name = "Ime")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Opis proizvoda je obavezan")]
		[Display(Name = "Opis")]
		public string Description { get; set; }

		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "Molimo unesite ispravnu cijenu")]
		[DataType(DataType.Currency)]
		[Display(Name = "Cijena")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Kategorija proizvoda je obavezna")]
		[Display(Name = "Kategorija")]
		public string Category { get; set; }
	}
}