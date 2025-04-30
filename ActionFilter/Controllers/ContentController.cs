using ActionFilter.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContentController : ControllerBase
	{
		[HttpPost("Add")]
		[AdminOnly]
		public IActionResult AddContect()
		{
			return Ok($"Content added: ");
		}
		[HttpGet("view")]
		public IActionResult ViewContent()
		{
			return Ok("Viewing content...");
		}


	}
}
