using DapperEstate.Dtos.ProductDtos;

namespace DapperEstate.Services
{
	public interface IProductService
	{
		Task<List<ResultProductDto>> GetAllProductsAsync();
		Task<List<ResultRecentProductDto>> RecentProductListAsync();
	}
}
