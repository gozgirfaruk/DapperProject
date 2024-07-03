using Dapper;
using DapperEstate.Areas.Admin.Dtos.PropertyDtos;
using DapperEstate.Context;
using DapperEstate.Dtos.ProductDtos;

namespace DapperEstate.Areas.Admin.Service
{
    public class PropService : IPropService
    {
        private readonly DapperContext _context;

        public PropService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreatePropDAsync(CreatePropDto dto)
        {
            string query = "Insert Into TblProperty (PropType) Values (@p1)";
            var parameters = new DynamicParameters();
            parameters.Add("@p1",dto.PropType);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeletePropAsync(int id)
        {
            string query = "Delete From TblProperty Where PropertyID=@p1";
            var parameters = new DynamicParameters();
            parameters.Add("@p1",id);
            var connection = _context.CreateConnection();
             await connection.ExecuteAsync(query, parameters);  

        }

        public async Task<List<ResultPropDto>> GetAllProductsAsync()
        {
            string query = "Select * From TblProperty";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultPropDto>(query);  
            return values.ToList();
        }

        public async Task<GetPropByIdDto> GetPropByIdAsync(int id)
        {
            string query = "Select * From TblProperty Where PropertyID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", id);
            var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<GetPropByIdDto>(query,parameter);
        }

        public async Task UpdatePropAsync(UpdatePropDto dto)
        {
            string query = "Update TblProperty Set PropType=@p1 where PropertyID=@p2";
            var parameters = new DynamicParameters();
            parameters.Add("@p1",dto.PropType);
            parameters.Add("@p2", dto.PropertyID);
            var connection = _context.CreateConnection();   
            await connection.ExecuteAsync(query, parameters);

        }
    }
}
