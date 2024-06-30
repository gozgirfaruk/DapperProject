using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.ViewComponents
{
    public class _SingleProductContentComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _SingleProductContentComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _productService.SingleProductDetail(id);
            return View(values);
        }
    }
}
