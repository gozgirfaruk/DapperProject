using DapperEstate.Dtos.ProductDtos;

namespace DapperEstate.Services
{
    public interface ISearchService
    {
        Task<List<ResultProductDto>> SearchProduct(CreateSearchDto createSearchDto);
    }
}
