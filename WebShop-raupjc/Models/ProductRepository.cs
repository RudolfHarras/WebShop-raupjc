using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShop_raupjc.Models
{

	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;

		public ProductRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Product> Products => _context.Products;

		public void SaveProduct(Product product)
		{
			if (product.ProductId == 0)
			{
				_context.Products.Add(product);
			}
			else
			{
				Product dbEntry = _context.Products
					.FirstOrDefault(p => p.ProductId == product.ProductId);
				if (dbEntry != null)
				{
					dbEntry.Name = product.Name;
					dbEntry.Description = product.Description;
					dbEntry.Price = product.Price;
					dbEntry.Category = product.Category;
				}
			}
			_context.SaveChanges();
		}

		public bool DeleteProduct(int productId)
		{
			Product dbEntry = _context.Products
				.FirstOrDefault(p => p.ProductId == productId);
			if (dbEntry == null) return false;
			_context.Products.Remove(dbEntry);
			try
			{
				_context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}