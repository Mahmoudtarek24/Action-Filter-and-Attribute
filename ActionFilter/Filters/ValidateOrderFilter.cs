using ActionFilter.Dto_s;
using ActionFilter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilter.Filters
{
	public class ValidateOrderFilter : IAsyncActionFilter
	{
		private readonly IProductService productService;
		public ValidateOrderFilter(IProductService productService)
		{
			this.productService = productService;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			// check modelstate for data annotation
			if (!context.ModelState.IsValid) 
			{
				context.Result = new BadRequestObjectResult(context.ModelState);
				return;
			}

			var order = context.ActionArguments["order"] as OrderModel;
			if (order == null) 
			{
				context.Result=new BadRequestObjectResult(new { error = "Order data is missing" });
				return;
			}

			//Adds custom business logic to verify if the ProductId exists

			var result =await productService.ProductExistsAsync(order.ProductId);
			if (!result)
			{
				context.ModelState.AddModelError("ProductId", "Product does not exist");
				context.Result = new BadRequestObjectResult(context.ModelState);
			}

			//if the Quantity is within available stock
			var availableOnStock=await productService.GetAvailableStockAsync(order.ProductId);

			if (availableOnStock < order.Quantity)
			{
				context.ModelState.AddModelError("Quantity", $"Requested quantity exceeds available stock ({availableOnStock})");
				context.Result = new BadRequestObjectResult(context.ModelState);
			}
			await next();	
		}
	}
}
//Step 2: Create the Action Filter for Validation
//We’ll create an Action Filter called ValidateOrderFilter that:

//Checks ModelState for data annotation violations.
//Adds custom business logic to verify if the ProductId exists
//and if the Quantity is within available stock (simulated with a mock service).