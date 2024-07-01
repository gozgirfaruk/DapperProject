using DapperEstate.Dtos.ProductDtos;
using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.Controllers
{
	public class FindProductController : Controller
	{
		private readonly ISearchService _searchService;

		public FindProductController(ISearchService searchService)
		{
			_searchService = searchService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> ListFilter(CreateSearchDto dto)
		{
			var values = await _searchService.SearchProduct(dto);
			return View(values);
		}
	}
}
