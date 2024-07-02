using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
