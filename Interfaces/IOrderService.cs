using System.Collections.Generic;
using System.Threading.Tasks;
using ECommercePlatform.Models;

namespace ECommercePlatform.Services
{
	public interface IOrderService
	{
		Task<Order> CreateOrderAsync(string userId, List<CartItem> items);
		Task<Order> GetOrderByIdAsync(int orderId);
		Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
	}
}
