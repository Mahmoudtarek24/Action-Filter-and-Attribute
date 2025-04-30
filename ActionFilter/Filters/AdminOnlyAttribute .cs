using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace ActionFilter.Filters
{
	public class AdminOnlyAttribute : ActionMethodSelectorAttribute
	{
		public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
		{
			//check from queryString have name Admin with Value Role

			var query=routeContext.HttpContext.Request.Query;

			return query.TryGetValue("role", out var role) && role == "admin";
		}
	}
}
