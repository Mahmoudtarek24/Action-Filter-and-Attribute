using System.ComponentModel.DataAnnotations;

namespace ActionFilter.Dto_s
{
	public class ProductDto
	{
		[Required]
		public string Name { get; set; } = null!;
		[Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
		public decimal Price { get; set; }	
	}
}
