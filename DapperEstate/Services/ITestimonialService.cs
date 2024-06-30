using DapperEstate.Dtos.TestimonialDtos;

namespace DapperEstate.Services
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetTestimonials();
    }
}
