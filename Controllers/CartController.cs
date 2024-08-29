using ECommercePlatform.Models;
using ECommercePlatform.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommercePlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Cart>> GetCart(string userId)
        {
            var cart = await _cartService.GetCartAsync(userId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddItemToCart([FromBody] CartItemDto dto)
        {
            var item = new CartItem
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };
            await _cartService.AddItemToCartAsync(dto.UserId, item);
            return NoContent();
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveItemFromCart([FromBody] CartItemDto dto)
        {
            await _cartService.RemoveItemFromCartAsync(dto.UserId, dto.ProductId);
            return NoContent();
        }
    }

    public class CartItemDto
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
