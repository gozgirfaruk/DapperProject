using DapperEstate.Dtos.ProductDtos;
using DapperEstate.Models;
using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DapperEstate.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IProductService _productService;

        public PropertyController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> PropertyList(SearchPropertyViewModel? model, int sayfa = 1)
        {
            if (!string.IsNullOrEmpty(model.Location))
            {
                var values = await _productService.GetAllPropertyByFilterAsync(model);
                var result = values.ToList().ToPagedList(sayfa, 6);
                return View(result);
            }
            {
                var values = await _productService.GetAllProductsAsync();
                return View(values.ToList().ToPagedList(sayfa, 6));
            }

        }

        public IActionResult PropertyDetail(int id)
        {
            ViewBag.Id = id;
            return View();
        }





    }
}
