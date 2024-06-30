using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.ViewComponents
{
	public class _CounterComponentPartial : ViewComponent
	{
		private readonly IProductService _productService;

		public _CounterComponentPartial(IProductService productService)
		{
			_productService = productService;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.one = _productService.StatisticsOne();
			ViewBag.three = _productService.StatisticsThree();
			ViewBag.four = _productService.StatisticsFour();
			ViewBag.two= _productService.StatisticsTwo();
			return View();
		}
	}
}
