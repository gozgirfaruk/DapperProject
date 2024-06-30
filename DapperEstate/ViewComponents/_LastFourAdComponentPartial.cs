using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.ViewComponents
{
	public class _LastFourAdComponentPartial : ViewComponent
	{
		private readonly IProductService _productService;

		public _LastFourAdComponentPartial(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _productService.LastFourProductListAsync();
			return View(values);
		}
	}
}
