using DapperEstate.Areas.Admin.Dtos.SliderDtos;
using DapperEstate.Areas.Admin.Service;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]")]
	public class SliderController : Controller
	{
		private readonly IAdminSliderService _sliderService;

		public SliderController(IAdminSliderService sliderService)
		{
			_sliderService = sliderService;
		}

		public async Task<IActionResult> SliderList()
		{
			var values = await _sliderService.GetSliderListAsync();
			return View(values);
		}
		[Route("{id}")]
		public async Task<IActionResult> DeleteSlider(int id)
		{
			await _sliderService.DeleteSliderAsync(id);
			return RedirectToAction("SliderList");
		}


		[HttpGet]
		public IActionResult CreateSlider()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateSlider(CreateSliderDto dto)
		{
			await _sliderService.CreateSliderAsync(dto);
			return RedirectToAction("SliderList");
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> UpdateSlider(int id)
		{
			var values = await _sliderService.GetByIdSliderAsync(id);
			return View(values);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateSliderIndex(UpdateSliderDto dto)
		{
			await _sliderService.UpdateSliderAsync(dto);
			return RedirectToAction("SliderList");
		}
	}
}
