using Microsoft.AspNetCore.Mvc;
using WebShop_raupjc.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebShop_raupjc.Controllers
{

	public class OrderController : Controller
	{
		private readonly IOrderRepository _repository;
		private readonly Cart _cart;

		public OrderController(IOrderRepository repoService, Cart cartService)
		{
			_repository = repoService;
			_cart = cartService;
		}

		[Authorize]
		public ViewResult List() =>
			View(_repository.Orders.Where(o => !o.Shipped));

		[HttpPost]
		[Authorize]
		public IActionResult MarkShipped(int orderId)
		{
			Order order = _repository.Orders
				.FirstOrDefault(o => o.OrderId == orderId);
			if (order == null) return RedirectToAction(nameof(List));
			order.Shipped = true;
			_repository.SaveOrder(order);
			return RedirectToAction(nameof(List));
		}

		[Authorize]
		public ViewResult Checkout() => View(new Order());

		[HttpPost]
		[Authorize]
		public IActionResult Checkout(Order order)
		{
			if (!_cart.Lines.Any())
			{
				ModelState.AddModelError("", "Košarica je prazna!");
			}
			if (ModelState.IsValid)
			{
				order.Lines = _cart.Lines.ToArray();
				_repository.SaveOrder(order);
				return RedirectToAction(nameof(Completed));
			}
			return View(order);
		}

		public ViewResult Completed()
		{
			_cart.Clear();
			return View();
		}
	}
}