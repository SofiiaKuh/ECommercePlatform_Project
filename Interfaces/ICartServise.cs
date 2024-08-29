using ECommercePlatform.Models;
using System.Threading.Tasks;

namespace ECommercePlatform.Services
{
	public interface ICartService
	{
		Task AddItemToCartAsync(string userId, CartItem item);
		Task<Cart> GetCartAsync(string userId);
		Task RemoveItemFromCartAsync(string userId, int itemId);
		Task UpdateItemQuantityAsync(string userId, int itemId, int quantity);
		Task ClearCartAsync(string userId);
	}
}
