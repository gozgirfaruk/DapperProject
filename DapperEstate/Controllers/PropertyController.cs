using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.Controllers
{
	public class PropertyController : Controller
	{
		public IActionResult PropertyList()
		{
			return View();
		}
	}
}
