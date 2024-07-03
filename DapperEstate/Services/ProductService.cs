using Dapper;
using DapperEstate.Context;
using DapperEstate.Dtos.ProductDtos;
using DapperEstate.Dtos.SingleProductDtos;
using DapperEstate.Models;

namespace DapperEstate.Services
{
	public class ProductService : IProductService
	{
		private readonly DapperContext _context;

		public ProductService(DapperContext context)
		{
			_context = context;
		}

        public async Task<List<CategoryCountDto>> CategoryCountListAsync()
        {
			string query = "select TblProperty.PropType ,Count(*) As Tekrar from TblProduct Inner Join TblProperty On TblProduct.PropID=TblProperty.PropertyID Group By TblProduct.PropID, TblProperty.PropType";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<CategoryCountDto>(query);
			return values.ToList();
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
		{
			string query = "Select ProductID,Title,Price,Description2,CoverImage,NameSurname,PropStatus,PropType,City From TblProduct Inner Join TblProperty On TblProduct.PropID=TblProperty.PropertyID Inner Join TblLocation On TblProduct.LocationID = TblLocation.LocationID Inner Join TblAgent On TblProduct.AgentID = TblAgent.AgentID";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultProductDto>(query);
			return values.ToList();
		}

        public async Task<List<ResultProductDto>> GetAllPropertyByFilterAsync(SearchPropertyViewModel model)
        {
			string query = @"select Title,Price,CoverImage,City,PropID From TblProduct Inner Join TblLocation On TblProduct.LocationID=TblLocation.LocationID where City=@p1 OR (Price between @minprice and @maxprice) OR PropID=@p3";
			var parameters = new DynamicParameters();
			parameters.Add("@p1", model.Location);
			parameters.Add("@minprice", model.MinPrice);
			parameters.Add("@maxprice", model.MaxPrice);
			parameters.Add("@p3", model.PropID);
			var connect= _context.CreateConnection();
			var values = await connect.QueryAsync<ResultProductDto>(query,parameters);
			return values.ToList();

        }

        public async Task<List<LastFourProductDto>> LastFourProductListAsync()
		{
			string query = "Select ProductID,Title,Price,CoverImage,PropType,PropStatus,City From TblProduct Inner Join TblLocation On TblProduct.LocationID = TblLocation.LocationID  Inner Join TblProperty On TblProduct.PropID = TblProperty.PropertyID";
			var connection = _context.CreateConnection();	
			var values = await connection.QueryAsync<LastFourProductDto>(query);
			return values.OrderByDescending(x=>x.ProductID).Take(4).ToList();
		}

		public async Task<List<ResultRecentProductDto>> RecentProductListAsync()
		{
			string query = "select Title,Price,CoverImage,Recent,PropType,PropStatus,City From TblProduct Inner Join TblProperty On TblProduct.PropID=TblProperty.PropertyID Inner Join TblLocation On TblProduct.LocationID=TblLocation.LocationID where Recent=1";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultRecentProductDto>(query);
			return values.ToList();
		}

        public async Task<List<ResultSingleProductDto>> SingleProductDetail(int id)
        {
			string query = $"select Title,Price,Proptype,city,NameSurname,PropStatus,VideoUrl,Description2 From TblProduct Inner Join TblProperty on TblProduct.PropID=TblProperty.PropertyID Inner Join TblLocation on TblProduct.LocationID=TblLocation.LocationID Inner Join TblAgent on TblProduct.AgentID=TblAgent.AgentID where ProductID={id}";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultSingleProductDto>(query);
			return values.ToList();
        }

        public List<SingleProductImageDto> SingleProductImageList(int id)
        {
			string query = $"Select ImageUrl From TblImage where ProductID = {id}";
			var connection = _context.CreateConnection();
			var values = connection.Query<SingleProductImageDto>(query);
			return values.ToList();
        }

        public int StatisticsFour()
		{
			string query = "Select Count(*) From TblProduct where PropStatus=1";
			var connection = _context.CreateConnection();
			int values = connection.ExecuteScalar<int>(query);
			return values;
		}

		public int StatisticsOne()
		{
			string query = "Select Count(*) From TblProduct";
			var connection = _context.CreateConnection();
			int values = connection.ExecuteScalar<int>(query);	
			return values;
		}

		public int StatisticsThree()
		{
			string query = "Select Count(*) From TblProduct where PropStatus=0";
			var connection = _context.CreateConnection();
			int values = connection.ExecuteScalar<int>(query);
			return values;
		}

		public int StatisticsTwo()
		{
			string query = "Select Price From TblProduct Order By Price Desc";
			var connection = _context.CreateConnection();
			var values = connection.ExecuteScalar<int>(query);
			return values;
		}
	}
}
