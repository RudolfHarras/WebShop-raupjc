using System.Collections.Generic;

namespace WebShop_raupjc.Models
{

	public interface IOrderRepository
	{

		IEnumerable<Order> Orders { get; }
		void SaveOrder(Order order);
	}
}