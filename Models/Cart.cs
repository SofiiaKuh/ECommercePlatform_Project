namespace ECommercePlatform.Models
{
	public class Cart
	{
		public int Id { get; set; }
		public string? UserId { get; set; }
		public ICollection<CartItem>? Items { get; set; }
	}

	public class CartItem
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public Product? Product { get; set; }
	}
}
