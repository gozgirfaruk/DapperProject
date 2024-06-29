using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.ViewComponents
{
    public class _PropListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _PropListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductsAsync();
            return View(values);
        }
    }
}
