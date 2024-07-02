using Dapper;
using DapperEstate.Areas.Admin.Dtos.CityDtos;
using DapperEstate.Context;
using System.Net.Http.Headers;

namespace DapperEstate.Areas.Admin.Service
{
	public class CityService : ICityService
	{
		private readonly DapperContext _context;

		public CityService(DapperContext context)
		{
			_context = context;
		}

		public async Task CreateCityAsync(CreateCityDto city)
		{
			string query = "Insert Into TblLocation (City) values (@p1)";
			var parameters = new DynamicParameters();
			parameters.Add("@p1",city.City);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query,parameters);
		}

		public async Task<List<ResultCityDto>> GetAllCityAsync()
		{
			string query = "Select * From TblLocation";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultCityDto>(query);
			return	values.ToList();
		}

		public async Task DeleteCityAsync(int id)
		{
			string query = "Delete From TblLocation Where LocationID=@p1";
			var parameters = new DynamicParameters();
			parameters.Add("@p1",id);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query,parameters);
		}
	}
}
