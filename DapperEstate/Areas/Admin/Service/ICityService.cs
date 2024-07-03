using DapperEstate.Areas.Admin.Dtos.CityDtos;

namespace DapperEstate.Areas.Admin.Service
{
	public interface ICityService
	{
		Task<List<ResultCityDto>> GetAllCityAsync();
		Task CreateCityAsync(CreateCityDto city);
		Task DeleteCityAsync(int id);
		Task UpdateCityAsync(UpdateCityDto city);
		Task<GetCityDto> GetCityAsync(int id);
	}
}
