using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebShop_raupjc.Models
{

	public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContext _context;

		public OrderRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Order> Orders => _context.Orders
			.Include(o => o.Lines)
			.ThenInclude(l => l.Product);

		public void SaveOrder(Order order)
		{
			_context.Database.EnsureCreated();
			_context.AttachRange(order.Lines.Select(l => l.Product));
			
			if (order.OrderId == 0)
			{
				_context.Orders.Add(order);
			}
			_context.SaveChanges();
		}
	}
}