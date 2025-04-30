using ActionFilter.Dto_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilter.Filters
{
	public class ValidateInputAttribute :ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ModelState.IsValid)
			{
				context.Result = new ObjectResult(context.ModelState);
				return;
			}

			foreach(var argument in context.ActionArguments)
			{
				if(argument.Value is ProductDto product)
				{
					if (string.IsNullOrWhiteSpace(product.Name) || product.Name.Length < 3)
					{
						context.ModelState.AddModelError("Name", "Product name must be at least 3 characters long.");
					}
					if (product.Price <= 0)
					{
						context.ModelState.AddModelError("Price", "Price must be greater than zero.");
					}
				}

				if(argument.Key== "minPrice"&& argument.Value is decimal minPrice)
				{
					if (minPrice < 0)
					{
						context.ModelState.AddModelError("minPrice", "Minimum price cannot be negative.");
					}
				}

			}
			if (!context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult(context.ModelState); //==400 bad request
			}

		}
	}
}
