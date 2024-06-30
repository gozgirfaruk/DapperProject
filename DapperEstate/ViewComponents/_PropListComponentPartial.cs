using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DapperEstate.ViewComponents
{
    public class _PropListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _PropListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int sayfa =1)
        {
            var values = await _productService.GetAllProductsAsync();
            return View(values.ToList().ToPagedList(sayfa,10));
        }
    }
}
