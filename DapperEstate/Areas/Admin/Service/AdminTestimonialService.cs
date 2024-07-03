using Dapper;
using DapperEstate.Areas.Admin.Dtos.TestimonialDtos;
using DapperEstate.Context;

namespace DapperEstate.Areas.Admin.Service
{
    public class AdminTestimonialService : IAdminTestimonialService
    {
        private readonly DapperContext _context;

        public AdminTestimonialService(DapperContext context)
        {
            _context = context;
        }

		public async Task DeleteTestimonialAsync(int id)
        {
            string query = "Delete TblTestimonial Where TestimonialID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1",id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query,parameter);
        }

        public async Task<GetTestByIDDto> GetTestimonialByIdAsync(int id)
        {
            string query = "Select * From TblTestimonial Where TestimonialID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", id);
            var connection = _context.CreateConnection();   
            var values = await connection.QueryFirstOrDefaultAsync<GetTestByIDDto>(query,parameter);
            return values;
        }

        public async Task<List<ResultTestListDto>> GetTestimonialListAsync()
        {
            string query = "Select * From TblTestimonial";
            var connection=_context.CreateConnection();
            var values = await connection.QueryAsync<ResultTestListDto>(query);
            return values.ToList();
        }

        public async Task UpdateTestimonialAsync(UpdateTestDto updateTestDto)
        {
            string query = "Update TblTestimonial Set (NameSurname=@p1, Title=@p2, ImageUrl=@p3, Description=@p4) Where TestimonialID=@p5";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", updateTestDto.NameSurname);
            parameter.Add("@p2", updateTestDto.Title);
            parameter.Add("@p3", updateTestDto.ImageUrl);
            parameter.Add("@p4", updateTestDto.Description);
            parameter.Add("@p5", updateTestDto.TestimonialID);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameter);
        }
    }
}
