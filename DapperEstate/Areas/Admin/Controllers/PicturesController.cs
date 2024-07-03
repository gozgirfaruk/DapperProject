using DapperEstate.Areas.Admin.Service.AdminPictureService;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PicturesController : Controller
    {
        private readonly IPictureService _pictureService;

        public PicturesController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public async Task<IActionResult> PictureList(int id)
        {
            var values = await _pictureService.GetPictureAsync(id);
            return View(values);
        }
    }
}
