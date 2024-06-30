using DapperEstate.Dtos.ProductDtos;
using DapperEstate.Dtos.SearchDtos;

namespace DapperEstate.Services
{
    public interface ISearchProductService
    {
        Task<List<ResultProductDto>> CreateSearchProductAsync(CreateSearchProductDto dto); 
    }
}
