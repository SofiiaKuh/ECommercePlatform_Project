using System.Threading.Tasks;
using ECommercePlatform.Data;
using ECommercePlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommercePlatform.Services
{
	public class CartService : ICartService
	{
		private readonly ApplicationDbContext _context;

		public CartService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task AddItemToCartAsync(string userId, CartItem item)
		{
			var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
			if (cart == null)
			{
				cart = new Cart { UserId = userId };
				_context.Carts.Add(cart);
			}

			cart.Items.Add(item);
			await _context.SaveChangesAsync();
		}

		public async Task<Cart> GetCartAsync(string userId)
		{
			return await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
		}

		public async Task RemoveItemFromCartAsync(string userId, int itemId)
		{
			var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
			if (cart != null)
			{
				var item = cart.Items.FirstOrDefault(i => i.Id == itemId);
				if (item != null)
				{
					cart.Items.Remove(item);
					await _context.SaveChangesAsync();
				}
			}
		}

		public async Task UpdateItemQuantityAsync(string userId, int itemId, int newQuantity)
		{
			var cart = await _context.Carts
				.Include(c => c.Items)
				.FirstOrDefaultAsync(c => c.UserId == userId);

			if (cart == null)
				throw new InvalidOperationException("Cart not found.");

			var item = cart.Items.FirstOrDefault(i => i.Id == itemId);
			if (item == null)
				throw new InvalidOperationException("Item not found.");

			item.Quantity = newQuantity;
			await _context.SaveChangesAsync();
		}


		public async Task ClearCartAsync(string userId) // Implement the ClearCartAsync method
		{
			var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
			if (cart != null)
			{
				_context.CartItems.RemoveRange(cart.Items); // Remove all items from the cart
				cart.Items.Clear();
				await _context.SaveChangesAsync();
			}
		}
	}
}
