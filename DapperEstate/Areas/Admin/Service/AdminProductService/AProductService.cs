using Dapper;
using DapperEstate.Areas.Admin.Dtos.AProductDtos;
using DapperEstate.Context;

namespace DapperEstate.Areas.Admin.Service.AdminProductService
{
    public class AProductService : IAProductService
    {
        private readonly DapperContext _context;

        public AProductService(DapperContext context)
        {
            _context = context;
        }

        public async Task ChangerPropTypeToRent(int id)
        {
            string query = "Update TblProduct Set PropStatus=1 Where ProductID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1",id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameter);
        }

        public async Task ChangerPropTypeToSale(int id)
        {
            string query = "Update TblProduct Set PropStatus=0 Where ProductID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameter);
        }

        public async Task DeleteProductAsync(int id)
        {
            string query = "Delete From  TblProduct Where ProductID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameter);
        }

        public async Task<List<AResultProductDto>> GetAllProductListAsync()
        {
            string query = "Select ProductID,Title,CoverImage,Price,PropType,City,PropStatus,Recent From TblProduct Inner Join TblProperty On TblProduct.PropID=TblProperty.PropertyID Inner Join TblLocation On TblProduct.LocationID=TblLocation.LocationID";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<AResultProductDto>(query);
            return values.ToList();
        }

        public async Task NoShowRoomProduct(int id)
        {
            string query = "Update TblProduct Set Recent=0 Where ProductID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameter);
        }

        public async Task YesShowRoomProduct(int id)
        {
            string query = "Update TblProduct Set Recent=1 Where ProductID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameter);
        }
    }
}
