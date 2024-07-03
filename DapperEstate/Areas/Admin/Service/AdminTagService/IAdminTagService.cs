using DapperEstate.Areas.Admin.Dtos.TagsDtos;

namespace DapperEstate.Areas.Admin.Service.AdminTagService
{
    public interface IAdminTagService
    {
        Task<List<ResultTagDto>> GetAllTagListAsync(int id);
        Task<List<ResultTagDto>> GettAllTagListNoIDAsync();
        Task DeleteTagAsync(int id);
    }
}
