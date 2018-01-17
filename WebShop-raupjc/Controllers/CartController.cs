using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop_raupjc.Models;
using WebShop_raupjc.Models.ViewModels;
using WebShop_raupjc.Extensions;

namespace WebShop_raupjc.Controllers
{

	public class CartController : Controller
	{
		private readonly IProductRepository _repository;

		public CartController(IProductRepository repo)
		{
			_repository = repo;
		}

		public ViewResult Index(string returnUrl)
		{
			return View(new CartIndexViewModel
			{
				Cart = GetCart(),
				ReturnUrl = returnUrl
			});
		}

		public RedirectToActionResult AddToCart(int productId, string returnUrl)
		{
			Product product = _repository.Products
				.FirstOrDefault(p => p.ProductId == productId);

			if (product == null) return RedirectToAction("Index", new {returnUrl});

			Cart cart = GetCart();
			cart.AddItem(product, 1);
			SaveCart(cart);
			return RedirectToAction("Index", new { returnUrl });
		}

		[Authorize]
		public RedirectToActionResult RemoveFromCart(int productId,
			string returnUrl)
		{
			Product product = _repository.Products
				.FirstOrDefault(p => p.ProductId == productId);

			if (product != null)
			{
				Cart cart = GetCart();
				cart.RemoveLine(product);
				SaveCart(cart);
			}
			return RedirectToAction("Index", new { returnUrl });
		}

		[Authorize]
		private Cart GetCart()
		{
		Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
		return cart;
		}
		
		[Authorize]
		private void SaveCart(Cart cart)
		{
		HttpContext.Session.SetJson("Cart", cart);
		}
	}
}