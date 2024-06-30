using DapperEstate.Dtos.ProductDtos;
using DapperEstate.Dtos.SearchDtos;
using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DapperEstate.Controllers
{
	public class PropertyController : Controller
	{
        private readonly IProductService _productService;
        private readonly ISearchProductService _searchService;

		public PropertyController(IProductService productService, ISearchProductService searchService)
		{
			_productService = productService;
			_searchService = searchService;
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
