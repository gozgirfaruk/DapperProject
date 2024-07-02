using DapperEstate.Areas.Admin.Dtos.PropertyDtos;
using DapperEstate.Dtos.ProductDtos;

namespace DapperEstate.Areas.Admin.Service
{
    public interface IPropService
    { 
        Task<List<ResultPropDto>> GetAllProductsAsync();

        Task DeletePropAsync(int id);
        Task CreatePropDAsync(CreatePropDto dto);
    }
}
