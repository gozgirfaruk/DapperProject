using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
