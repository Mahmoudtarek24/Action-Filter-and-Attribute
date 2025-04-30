using ActionFilter.Dto_s;
using ActionFilter.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		[HttpPost]
		[ValidateInput]
		public IActionResult CreateProduct(ProductDto product)
		{
			// If we reach here, the input is valid
			return Ok(new { Message = "Product created successfully", Product = product });
		}

		[HttpGet]
		[ValidateInput]
		public IActionResult GetProductsByPrice([FromQuery] decimal minPrice)
		{
			// If we reach here, minPrice is valid
			return Ok(new { Message = $"Products with price >= {minPrice}" });
		}
	}
}
