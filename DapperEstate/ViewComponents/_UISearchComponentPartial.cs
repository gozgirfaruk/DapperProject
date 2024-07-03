using DapperEstate.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.ViewComponents
{
	public class _UISearchComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(new SearchPropertyViewModel());
		}
	}
}
