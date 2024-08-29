using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommercePlatform.Data;
using ECommercePlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommercePlatform.Services
{
	public class OrderService : IOrderService
	{
		private readonly ApplicationDbContext _context;

		public OrderService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Order> CreateOrderAsync(string userId, List<CartItem> items)
		{
			var order = new Order
			{
				UserId = userId,
				Items = items, // Direct assignment to ICollection<CartItem>
				TotalAmount = items.Sum(i => i.Quantity * 10), // Example calculation
				Status = OrderStatus.Pending
			};

			_context.Orders.Add(order);
			await _context.SaveChangesAsync();
			return order;
		}

		public async Task<Order> GetOrderByIdAsync(int orderId)
		{
			return await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == orderId);
		}

		public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
		{
			return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
		}
	}
}
