using Dapper;
using DapperEstate.Context;
using DapperEstate.Dtos.ProductDtos;

namespace DapperEstate.Services
{
	public class ProductService : IProductService
	{
		private readonly DapperContext _context;

		public ProductService(DapperContext context)
		{
			_context = context;
		}

		public async Task<List<ResultProductDto>> GetAllProductsAsync()
		{
			string query = "Select Title,Price,Description2,CoverImage,NameSurname,PropStatus,PropType,City From TblProduct Inner Join TblProperty On TblProduct.PropID=TblProperty.PropertyID Inner Join TblLocation On TblProduct.LocationID = TblLocation.LocationID Inner Join TblAgent On TblProduct.AgentID = TblAgent.AgentID";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultProductDto>(query);
			return values.ToList();
		}

		public async Task<List<ResultRecentProductDto>> RecentProductListAsync()
		{
			string query = "select Title,Price,CoverImage,Recent,PropType From TblProduct Inner Join TblProperty On TblProduct.PropID=TblProperty.PropertyID where Recent=1";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultRecentProductDto>(query);
			return values.ToList();
		}
	}
}
