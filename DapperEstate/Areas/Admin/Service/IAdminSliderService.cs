using DapperEstate.Areas.Admin.Dtos.SliderDtos;

namespace DapperEstate.Areas.Admin.Service
{
	public interface IAdminSliderService
	{
		Task<List<ResultSliderDto>> GetSliderListAsync();
		Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
		Task DeleteSliderAsync(int id);
		Task CreateSliderAsync(CreateSliderDto createSliderDto);
		Task<GetSliderDto> GetByIdSliderAsync(int id);
	}
}
