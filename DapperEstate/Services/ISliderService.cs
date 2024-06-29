using DapperEstate.Dtos.SliderDtos;

namespace DapperEstate.Services
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GettAllSliderAsync();
        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task DeleteSliderAsync(int id);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task<GetSliderDto> GetByIdSliderAsync(int id);
        
    }
}
