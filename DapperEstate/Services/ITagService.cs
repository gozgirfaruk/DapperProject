using DapperEstate.Dtos.TagDtos;

namespace DapperEstate.Services
{
    public interface ITagService
    {
        Task<List<ResultTagByProductDto>> TagListByProductAsync(int id);
    }
}
