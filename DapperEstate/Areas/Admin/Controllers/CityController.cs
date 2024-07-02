using DapperEstate.Areas.Admin.Service;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DapperEstate.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]")]
	public class CityController : Controller
	{
		private readonly ICityService _cityService;

		public CityController(ICityService cityService)
		{
			_cityService = cityService;
		}

		public async Task<IActionResult> CityList(int sayfa=1)
		{
			var values =await _cityService.GetAllCityAsync();
			return View(values.ToPagedList(sayfa,10));
		}
	}
}
