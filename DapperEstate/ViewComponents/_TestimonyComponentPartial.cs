using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.ViewComponents
{
    public class _TestimonyComponentPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonyService;

		public _TestimonyComponentPartial(ITestimonialService testimonyService)
		{
			_testimonyService = testimonyService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonyService.GetTestimonials();
            return View(values);
        }
    }
}
