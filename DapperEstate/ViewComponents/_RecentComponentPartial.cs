using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.ViewComponents
{
    public class _RecentComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

		public _RecentComponentPartial(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.RecentProductListAsync();
            return View(values);
        }
    }
}
