using ActionFilter.Dto_s;
using ActionFilter.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		[HttpPost]
		[ServiceFilter(typeof(ValidateOrderFilter))]
		public IActionResult PlaceOrder([FromBody] OrderModel order)
		{
			// If we reach here, the order is valid
			return Ok($"Order placed for Product ID {order.ProductId}, Quantity {order.Quantity}, shipped to {order.ShippingAddress}");
		}
	}
}
