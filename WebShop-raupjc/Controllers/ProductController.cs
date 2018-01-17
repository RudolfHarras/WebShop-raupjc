using Microsoft.AspNetCore.Mvc;
using WebShop_raupjc.Models;
using System.Linq;
using WebShop_raupjc.Models.ViewModels;

namespace WebShop_raupjc.Controllers
{

	public class ProductController : Controller
	{
		private readonly IProductRepository _repository;
		public int PageSize = 10;

		public ProductController(IProductRepository repo)
		{
			_repository = repo;
		}

		public ViewResult List(string category, int page = 1)
			=> View(new ProductsViewModel
			{
				Products = _repository.Products
					.Where(p => category == null || p.Category == category)
					.OrderBy(p => p.ProductId)
					.Skip((page - 1) * PageSize)
					.Take(PageSize),
				PagingInfo = new PagingInfo
				{
					CurrentPage = page,
					ItemsPerPage = PageSize,
					TotalItems =
						category == null ? _repository.Products.Count() : _repository.Products.Count(e => e.Category == category)
				},
				CurrentCategory = category
			});

		public ViewResult Info(int productId) =>
			View(_repository.Products
				.FirstOrDefault(p => p.ProductId == productId));


	}
}