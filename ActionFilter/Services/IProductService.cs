namespace ActionFilter.Services
{
	public interface IProductService
	{
		Task<bool> ProductExistsAsync(int productId);
		Task<int> GetAvailableStockAsync(int productId);
	}
}
