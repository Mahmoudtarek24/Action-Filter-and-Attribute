using System.ComponentModel.DataAnnotations;

namespace ActionFilter.Dto_s
{
	public class OrderModel
	{
		[Required(ErrorMessage = "Product ID is required")]
		public int ProductId { get; set; }

		[Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "Shipping address is required")]
		[StringLength(200, ErrorMessage = "Shipping address cannot exceed 200 characters")]
		public string ShippingAddress { get; set; }
	}
}
