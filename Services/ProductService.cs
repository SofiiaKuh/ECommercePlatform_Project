using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommercePlatform.Data;
using ECommercePlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommercePlatform.Services
{
	public class ProductService : IProductService
	{
		private readonly ApplicationDbContext _context;

		public ProductService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Product> GetProductByIdAsync(int productId)
		{
			return await _context.Products.FindAsync(productId);
		}

		public async Task<IEnumerable<Product>> GetAllProductsAsync()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task AddProductAsync(Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateProductAsync(Product updatedProduct)
		{
			var existingProduct = await _context.Products.FindAsync(updatedProduct.Id);
			if (existingProduct == null)
			{
				throw new KeyNotFoundException("Product not found");
			}

			// Update fields
			existingProduct.Name = updatedProduct.Name;
			existingProduct.Price = updatedProduct.Price;
			existingProduct.Description = updatedProduct.Description;

			await _context.SaveChangesAsync();
		}

		public async Task DeleteProductAsync(int productId)
		{
			var product = await _context.Products.FindAsync(productId);
			if (product != null)
			{
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
		}
	}
}
