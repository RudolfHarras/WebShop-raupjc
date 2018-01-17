using Microsoft.AspNetCore.Mvc;
using WebShop_raupjc.Models;

namespace WebShop_raupjc.Components
{

	public class CartSummaryViewComponent : ViewComponent
	{
		private readonly Cart _cart;

		public CartSummaryViewComponent(Cart cartService)
		{
			_cart = cartService;
		}

		public IViewComponentResult Invoke()
		{
			return View(_cart);
		}
	}
}