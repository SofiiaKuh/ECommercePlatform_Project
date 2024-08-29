using System.Collections.Generic;

namespace ECommercePlatform.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
		public decimal TotalAmount { get; set; }
		public OrderStatus Status { get; set; }
	}

	public enum OrderStatus
	{
		Pending,
		Completed,
		Shipped,
		Delivered,
		Cancelled
	}
}
