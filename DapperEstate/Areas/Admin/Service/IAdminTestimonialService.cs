using DapperEstate.Areas.Admin.Dtos.TestimonialDtos;

namespace DapperEstate.Areas.Admin.Service
{
    public interface IAdminTestimonialService
    {
        Task<List<ResultTestListDto>> GetTestimonialListAsync();
        Task DeleteTestimonialAsync(int id);
        Task<GetTestByIDDto> GetTestimonialByIdAsync(int id);
        Task UpdateTestimonialAsync(UpdateTestDto updateTestDto);
    }
}
