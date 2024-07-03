using DapperEstate.Areas.Admin.Dtos.AProductDtos;

namespace DapperEstate.Areas.Admin.Service.AdminProductService
{
    public interface IAProductService
    {
        Task<List<AResultProductDto>> GetAllProductListAsync();
        Task CreateProductAsync(ACreateProductDto  createProductDto);
       
        Task<AGetByIdProductDto> GetByIDProductAsync(int id);
        Task UpdateProductAsync(AUpdateProductDto updateProductDto);
        Task DeleteProductAsync(int id);
        Task ChangerPropTypeToRent(int id);
        Task ChangerPropTypeToSale(int id);
        Task YesShowRoomProduct(int id);
        Task NoShowRoomProduct(int id);
    }
}
