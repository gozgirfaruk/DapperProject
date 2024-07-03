
using DapperEstate.Areas.Admin.Dtos.AProductDtos;
using DapperEstate.Areas.Admin.Dtos.PropertyDtos;
using DapperEstate.Areas.Admin.Service;
using DapperEstate.Areas.Admin.Service.AdminProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace DapperEstate.Areas.Admin.Controllers
{
    [Area("Admin")]

	public class ProductController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly IAProductService _productService;
		private readonly ICityService _cityService;
		private readonly IPropService _propService;
		private readonly IAgentService _agentService;


        public ProductController(IAProductService productService, ICityService cityService, IPropService propService, IAgentService agentService)
        {
            _productService = productService;
            _cityService = cityService;
            _propService = propService;
            _agentService = agentService;
        }

        public async Task<IActionResult> ProductList(int sayfa=1)
		{
			var values = await _productService.GetAllProductListAsync();
			return View(values.ToList().ToPagedList(sayfa,8));
		}
		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			ViewBag.cityList = new SelectList(await _cityService.GetAllCityAsync(), "LocationID", "City");
			ViewBag.propList = new SelectList(await _propService.GetAllProductsAsync(), "PropertyID", "PropType");
			ViewBag.agentList = new SelectList(await _agentService.GetAllAgentListAsync(), "AgentID", "NameSurname");
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> CreateProduct(ACreateProductDto dto)
		{

			await _productService.CreateProductAsync(dto);
			return RedirectToAction("ProductList");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateProduct(int id)
		{
            ViewBag.cityList = new SelectList(await _cityService.GetAllCityAsync(), "LocationID", "City");
            ViewBag.propList = new SelectList(await _propService.GetAllProductsAsync(), "PropertyID", "PropType");
            ViewBag.agentList = new SelectList(await _agentService.GetAllAgentListAsync(), "AgentID", "NameSurname");
            var values = await _productService.GetByIDProductAsync(id);
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateProduct(AUpdateProductDto dto)
		{
			await _productService.UpdateProductAsync(dto);
			return RedirectToAction("ProductList");
		}
		public async Task<IActionResult> DeleteProduct(int id)
		{
			await _productService.DeleteProductAsync(id);
			return RedirectToAction("ProductList");
		}

		public async Task<IActionResult> ChangeToRent(int id)
		{
			await _productService.ChangerPropTypeToRent(id);
			return RedirectToAction("ProductList");
		}
        public async Task<IActionResult> ChangeToSale(int id)
        {
            await _productService.ChangerPropTypeToSale(id);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> YesShowRoomProduct(int id)
		{
			await _productService.YesShowRoomProduct(id);
			return RedirectToAction("ProductList");
		}

		public async Task<IActionResult> NoShowRoomProduct(int id)
		{
			await _productService.NoShowRoomProduct(id);
			return RedirectToAction("ProductList");
		}
    }
}
