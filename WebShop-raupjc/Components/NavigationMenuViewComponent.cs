using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebShop_raupjc.Models;

namespace WebShop_raupjc.Components
{

	public class NavigationMenuViewComponent : ViewComponent
	{
		private readonly IProductRepository _repository;

		public NavigationMenuViewComponent(IProductRepository repo)
		{
			_repository = repo;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.SelectedCategory = RouteData?.Values["category"];
			return View(_repository.Products
				.Select(x => x.Category)
				.Distinct()
				.OrderBy(x => x));
		}
	}
}