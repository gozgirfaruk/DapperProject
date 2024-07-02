using Dapper;
using DapperEstate.Areas.Admin.Dtos.CityDtos;
using DapperEstate.Context;

namespace DapperEstate.Areas.Admin.Service
{
	public class CityService : ICityService
	{
		private readonly DapperContext _context;

		public CityService(DapperContext context)
		{
			_context = context;
		}

		public Task CreateCityAsync(CreateCityDto city)
		{
			throw new NotImplementedException();
		}

		public async Task<List<ResultCityDto>> GetAllCityAsync()
		{
			string query = "Select * From TblLocation";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultCityDto>(query);
			return	values.ToList();
		}
	}
}
