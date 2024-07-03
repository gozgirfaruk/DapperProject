using DapperEstate.Areas.Admin.Dtos.TestimonialDtos;
using DapperEstate.Areas.Admin.Service;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class TestimonialController : Controller
    {
        private readonly IAdminTestimonialService _adminTestimonialService;

        public TestimonialController(IAdminTestimonialService adminTestimonialService)
        {
            _adminTestimonialService = adminTestimonialService;
        }
       
        public async Task<IActionResult> TestList()
        {
            var valeus = await _adminTestimonialService.GetTestimonialListAsync();
            return View(valeus);
        }

        [Route("{id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            await _adminTestimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("TestList");
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateTest(int id)
        {
            var values = await _adminTestimonialService.GetTestimonialByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTest(UpdateTestDto dto)
        {
            await _adminTestimonialService.UpdateTestimonialAsync(dto);
            return RedirectToAction("TestList");
        }

    }
}
