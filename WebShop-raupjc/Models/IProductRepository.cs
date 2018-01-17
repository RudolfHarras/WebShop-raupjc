using System.Collections.Generic;

namespace WebShop_raupjc.Models
{

	public interface IProductRepository
	{
		IEnumerable<Product> Products { get; }

		void SaveProduct(Product product);

		bool DeleteProduct(int productId);
	}
}