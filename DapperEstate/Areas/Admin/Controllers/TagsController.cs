using DapperEstate.Areas.Admin.Service.AdminTagService;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DapperEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagsController : Controller
    {
        private readonly IAdminTagService _adminTagService;

        public TagsController(IAdminTagService adminTagService)
        {
            _adminTagService = adminTagService;
        }

        public async Task<IActionResult> TagList(int id)
        {
            
            var values = await _adminTagService.GetAllTagListAsync(id);
            return View(values);
        }

        public async Task<IActionResult> NoIDTagList(int sayfa=1)
        {
            var values = await _adminTagService.GettAllTagListNoIDAsync();
            return View(values.ToList().ToPagedList(sayfa,10));
        }

        public async Task<IActionResult> DeleteTag(int id)
        {
            await _adminTagService.DeleteTagAsync(id);
            return RedirectToAction("NoIDTagList");
        }
    }
}
