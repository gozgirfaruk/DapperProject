using Dapper;
using DapperEstate.Areas.Admin.Dtos.TagsDtos;
using DapperEstate.Context;

namespace DapperEstate.Areas.Admin.Service.AdminTagService
{
    public class AdminTagService : IAdminTagService
    {
        private readonly DapperContext _context;

        public AdminTagService(DapperContext context)
        {
            _context = context;
        }

        public async Task DeleteTagAsync(int id)
        {
            string query = "Delete From TblTags where TagID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", id);
            var connection= _context.CreateConnection();
            await connection.ExecuteAsync(query, parameter);
        }

        public async Task<List<ResultTagDto>> GetAllTagListAsync(int id)
        {
            string query = "Select * From TblTags where ProductID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", id);
            var connection= _context.CreateConnection();
            var values = await connection.QueryAsync<ResultTagDto>(query,parameter);
            return values.ToList();
        }

        public async Task<List<ResultTagDto>> GettAllTagListNoIDAsync()
        {
            string query = "Select TagID,TagTitle,Title From TblTags Inner Join TblProduct On TblTags.ProductID=TblProduct.ProductID";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultTagDto>(query);
            return values.ToList() ;
        }
    }
}
