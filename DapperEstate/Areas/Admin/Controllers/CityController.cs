using DapperEstate.Areas.Admin.Dtos.CityDtos;
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
		public IActionResult CreateCity()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateCity(CreateCityDto dto)
		{
			await _cityService.CreateCityAsync(dto);
			return RedirectToAction("CityList");
		}

		[Route("{id}")]
		public async Task<IActionResult> DeleteCity(int id)
		{
			await _cityService.DeleteCityAsync(id);
			return RedirectToAction("CityList");
		}

	}
}
