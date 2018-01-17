using Microsoft.AspNetCore.Mvc;
using WebShop_raupjc.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebShop_raupjc.Controllers
{

	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly IProductRepository _repository;

		public AdminController(IProductRepository repo)
		{
			_repository = repo;
		}

		public ViewResult Index() => View(_repository.Products);

		public ViewResult Edit(int productId) =>
			View(_repository.Products
				.FirstOrDefault(p => p.ProductId == productId));

		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				_repository.SaveProduct(product);
				TempData["message"] = $"{product.Name} spremljen";
				return RedirectToAction("Index");
			}

			return View(product);
		}

		public ViewResult Create() => View("Create", new Product());

		[HttpPost]
		public IActionResult Delete(int productId)
		{
			bool deletedProduct = _repository.DeleteProduct(productId);
			if (deletedProduct)
			{
				TempData["message"] = "Artikl je obrisan";
			}
			else
			{
				TempData["message"] = "Artikl nije moguće obrisati jer se nalazi u narudžbi!";
			}
			return RedirectToAction("Index");
		}
	}
}