using Dapper;
using DapperEstate.Context;
using DapperEstate.Dtos.TestimonialDtos;

namespace DapperEstate.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly DapperContext _context;

        public TestimonialService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultTestimonialDto>> GetTestimonials()
        {
            string query = "Select * From TblTestimonial";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultTestimonialDto>(query);
            return values.ToList();
        }
    }
}
