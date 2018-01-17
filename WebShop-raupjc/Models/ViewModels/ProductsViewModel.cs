using System.Collections.Generic;

namespace WebShop_raupjc.Models.ViewModels
{
	public class ProductsViewModel
	{
		public IEnumerable<Product> Products { get; set; }
		public PagingInfo PagingInfo { get; set; }
		public string CurrentCategory { get; set; }
	}
}