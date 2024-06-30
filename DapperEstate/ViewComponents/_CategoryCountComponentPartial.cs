using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.ViewComponents
{
    public class _CategoryCountComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _CategoryCountComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.CategoryCountListAsync();
            return View(values);
        }
    }
}
