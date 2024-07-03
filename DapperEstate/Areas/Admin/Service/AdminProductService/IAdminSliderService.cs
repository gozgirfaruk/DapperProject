using DapperEstate.Areas.Admin.Dtos.SliderDtos;

namespace DapperEstate.Areas.Admin.Service.AdminProductService
{
    public interface IAdminSliderService
    {
        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task DeleteSliderAsync(int id);
        Task<GetSliderDto> GetByIdSliderAsync(int id);
        Task<List<ResultSliderDto>> GetSliderListAsync();
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);

    }
}
