using DapperEstate.Dtos.ProductDtos;
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

        public async Task<IActionResult> PropertyList(int sayfa = 1)
		{
            var values = await _productService.GetAllProductsAsync();
            return View(values.ToList().ToPagedList(sayfa, 6));
        }

        public IActionResult PropertyDetail(int id)
        {
            ViewBag.Id = id;
            return View();
        }

       

      

    }
}
