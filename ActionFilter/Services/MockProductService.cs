
namespace ActionFilter.Services
{
	public class MockProductService : IProductService
	{
		// Simulate: Product exists if ID is 1, 2, or 3
		public Task<bool> ProductExistsAsync(int productId)
		{
			return Task.FromResult(productId is 1 or 2 or 3);

		}
		public  Task<int> GetAvailableStockAsync(int productId)
		{
			// Simulate: Stock for product ID 1 is 50, ID 2 is 20, ID 3 is 0

			var stock = productId switch
			{
				1 => 50,
				2 => 20,
				3 => 0,
				_ => 0
			};
			return Task.FromResult(stock);

		}
	}
}
