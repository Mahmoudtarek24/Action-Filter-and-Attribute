using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace ActionFilter.Filters
{
	public class DeviceTypeAttribute : ActionMethodSelectorAttribute
	{
		private readonly string _deviceType;
		public DeviceTypeAttribute(string deviceType)
		{
			this._deviceType = deviceType;
		}

		public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
		{
			var userAgent = routeContext.HttpContext.Request.Headers["User-Agent"].ToString().ToLower();

			bool isMobile = userAgent.Contains("mobile") || userAgent.Contains("android") || userAgent.Contains("iphone");

			if(_deviceType=="mobile")
				return isMobile;
			else if (_deviceType == "desktop")
			{
				return !isMobile; 
			}

			return false;
		}
	}
}
