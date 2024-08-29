using System.Collections.Generic;
using System.Threading.Tasks;
using ECommercePlatform.Models;

namespace ECommercePlatform.Services
{
	public interface IProductService
	{
		Task<Product> GetProductByIdAsync(int productId);
		Task<IEnumerable<Product>> GetAllProductsAsync();
		Task AddProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(int productId);
	}
}
