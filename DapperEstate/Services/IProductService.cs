using DapperEstate.Dtos.ProductDtos;
using DapperEstate.Dtos.SingleProductDtos;
using DapperEstate.Models;


namespace DapperEstate.Services
{
	public interface IProductService
	{
		Task<List<ResultProductDto>> GetAllProductsAsync();
		Task<List<ResultRecentProductDto>> RecentProductListAsync();
		Task<List<LastFourProductDto>> LastFourProductListAsync();
		Task<List<CategoryCountDto>> CategoryCountListAsync();
        List<SingleProductImageDto> SingleProductImageList(int id);
		Task<List<ResultProductDto>> GetAllPropertyByFilterAsync(SearchPropertyViewModel model);

        Task<List<ResultSingleProductDto>> SingleProductDetail(int id);

		int StatisticsOne();
		int StatisticsThree();
		int StatisticsFour();
		int StatisticsTwo();
	}
}
