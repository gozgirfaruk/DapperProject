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

        public async Task CreateProductAsync(ACreateProductDto createProductDto)
        {
            string query = "Insert Into TblProduct (Title,Price,PropID,LocationID,AgentID,PropStatus,Recent,CoverImage,Description2,VideoUrl) Values (@title,@price,@propid,@locationid,@agentid,@propstatus,@recent,@image,@description,@video)";
            var parameter = new DynamicParameters();
            parameter.Add("@title", createProductDto.Title);
            parameter.Add("@propid",createProductDto.PropID);
            parameter.Add("@Price",createProductDto.Price);
            parameter.Add("@locationid",createProductDto.LocationID);
            parameter.Add("@agentid",createProductDto.AgentID);
            parameter.Add("@propstatus",createProductDto.PropStatus);
            parameter.Add("@recent", createProductDto.Recent);
            parameter.Add("@image", createProductDto.CoverImage);
            parameter.Add("@description", createProductDto.Description2);
            parameter.Add("@video",createProductDto.VideoUrl);
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

        public async Task<AGetByIdProductDto> GetByIDProductAsync(int id)
        {
            string query = "Select * From TblProduct Where ProductID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<AGetByIdProductDto>(query,parameter);
            return values;
        }

        public async Task NoShowRoomProduct(int id)
        {
            string query = "Update TblProduct Set Recent=0 Where ProductID=@p1";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameter);
        }

        public async Task UpdateProductAsync(AUpdateProductDto updateProductDto)
        {
            string query = "Update TblProduct Set Title=@p1,Price=@p2,PropID=@p3,LocationID=@p4,AgentID=@p5,CoverImage=@p6,Description2=@p7,VideoUrl=@p8 Where ProductID=@p9";
            var parameter = new DynamicParameters();
            parameter.Add("@p1", updateProductDto.Title);
            parameter.Add("@p2", updateProductDto.Price);
            parameter.Add("@p3", updateProductDto.PropID);
            parameter.Add("@p4", updateProductDto.LocationID);
            parameter.Add("@p5", updateProductDto.AgentID);
            parameter.Add("@p6", updateProductDto.CoverImage);
            parameter.Add("@p7", updateProductDto.Description2);
            parameter.Add("@p8", updateProductDto.VideoUrl);
            parameter.Add("@p9", updateProductDto.ProductID);
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
