using Dapper;
using DapperEstate.Areas.Admin.Dtos.PictureDtos;
using DapperEstate.Context;

namespace DapperEstate.Areas.Admin.Service.AdminPictureService
{
    public class PictureService : IPictureService
    {
        private readonly DapperContext _context;

        public PictureService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultPictureDto>> GetPictureAsync(int id)
        {
            string query = "Select * From TblImage Where ProductID =@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", id);
            var connection=_context.CreateConnection(); 
            var values = await connection.QueryAsync<ResultPictureDto>(query, parameter);
            return values.ToList();
        }
    }
}
