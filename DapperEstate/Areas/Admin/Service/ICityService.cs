using DapperEstate.Areas.Admin.Dtos.CityDtos;

namespace DapperEstate.Areas.Admin.Service
{
	public interface ICityService
	{
		Task<List<ResultCityDto>> GetAllCityAsync();
		Task CreateCityAsync(CreateCityDto city);
	}
}
