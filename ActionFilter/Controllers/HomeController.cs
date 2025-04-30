using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		[HttpGet]
		[ResponseCache(Duration = 60,NoStore =true)]	
		public string Index()
		{
			return $"Response Generated at: {DateTime.Now}";
		}
	}
}
