using ECommercePlatform.Models;
using ECommercePlatform.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommercePlatform.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;
		private readonly ICartService _cartService;

		public OrdersController(IOrderService orderService, ICartService cartService)
		{
			_orderService = orderService;
			_cartService = cartService;
		}

		[HttpPost("{userId}")]
		public async Task<IActionResult> CreateOrder(string userId)
		{
			// Get the cart for the user
			var cart = await _cartService.GetCartAsync(userId);

			if (cart == null || cart.Items.Count == 0)
			{
				return BadRequest("Cart is empty or does not exist.");
			}

			// Create the order using items from the cart
			var order = await _orderService.CreateOrderAsync(userId, cart.Items.ToList());

			// Assuming the cart is cleared after the order is placed
			await _cartService.ClearCartAsync(userId);

			return Ok(order);
		}
	}
}
