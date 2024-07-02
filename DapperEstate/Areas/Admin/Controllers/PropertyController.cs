using DapperEstate.Areas.Admin.Dtos.PropertyDtos;
using DapperEstate.Areas.Admin.Service;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class PropertyController : Controller
    {
        private readonly IPropService _propService;

        public PropertyController(IPropService propService)
        {
            _propService = propService;
        }
        
        public async Task<IActionResult> PropList()
        {
            var values = await _propService.GetAllProductsAsync();
            return View(values);
        }
        [Route("{id}")]
        public async Task<IActionResult> DeleteProp(int id)
        {
           await _propService.DeletePropAsync(id);
            return RedirectToAction("PropList");
        }

        public IActionResult CreateProp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProp(CreatePropDto dto)
        {
            await _propService.CreatePropDAsync(dto);
            return RedirectToAction("PropList");
        }
    }
}
