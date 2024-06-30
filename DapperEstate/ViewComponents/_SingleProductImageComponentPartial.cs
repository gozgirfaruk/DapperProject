using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.ViewComponents
{
    public class _SingleProductImageComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _SingleProductImageComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = _productService.SingleProductImageList(id);
            return View(values);
        }
    }
}
