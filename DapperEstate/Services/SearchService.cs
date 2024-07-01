using Dapper;
using DapperEstate.Context;
using DapperEstate.Dtos.ProductDtos;

namespace DapperEstate.Services
{
    public class SearchService : ISearchService
    {
        private readonly DapperContext _context;

        public SearchService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> SearchProduct(CreateSearchDto createSearchDto)
        {
            string query = "select *,NameSurname,City from TblProduct Inner Join TblAgent On TblProduct.AgentID=TblAgent.AgentID Inner Join TblLocation On TblProduct.LocationID=TblLocation.LocationID where Title=@p1 OR PropID=@p2 OR TblProduct.AgentID=@p3 Or TblProduct.LocationID=@p4";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", createSearchDto.Title);
            parameters.Add("@p2", createSearchDto.PropID);
            parameters.Add("@p3", createSearchDto.AgentID);
            parameters.Add("@p4", createSearchDto.LocationID);
            var connection = _context.CreateConnection();   
            var values = await connection.QueryAsync<ResultProductDto>(query, parameters);
            return values.ToList();
        }
    }
}
