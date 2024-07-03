using DapperEstate.Areas.Admin.Service.AdminProductService;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DapperEstate.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class ProductController : Controller
	{
		private readonly IAProductService _productService;

        public ProductController(IAProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductList(int sayfa=1)
		{
			var values = await _productService.GetAllProductListAsync();
			return View(values.ToList().ToPagedList(sayfa,8));
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
