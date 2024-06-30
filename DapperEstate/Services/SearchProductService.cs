using Dapper;
using DapperEstate.Context;
using DapperEstate.Dtos.ProductDtos;
using DapperEstate.Dtos.SearchDtos;

namespace DapperEstate.Services
{
    public class SearchProductService : ISearchProductService
    {
        private readonly DapperContext _context;

        public SearchProductService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> CreateSearchProductAsync(CreateSearchProductDto dto)
        {
            string query = "Select Title,PropType,Price,Description2,City,NameSurname,PropStatus from TblProduct Inner Join TblProperty On TblProduct.PropID=TblProperty.PropertyID Inner Join TblLocation On TblProduct.LocationID=TblLocation.LocationID Inner Join TblAgent On TblProduct.AgentID=TblAgent.AgentID Where Title=@p1 OR City=@p2 OR PropType=@p3 OR PropStatus=@p4 OR NameSurname=@p5";
            var parameters = new DynamicParameters();
            parameters.Add("@p1",dto.Title);
            parameters.Add("@p2", dto.City);
            parameters.Add("@p3", dto.PropType);
            parameters.Add("@p4", dto.PropStatus);
            parameters.Add("@p5", dto.NameSurname);
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultProductDto>(query,parameters);
            return values.ToList();
        }

	}
}
