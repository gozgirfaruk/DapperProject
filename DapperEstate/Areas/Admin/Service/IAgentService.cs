using DapperEstate.Areas.Admin.Dtos.AAgentDtos;

namespace DapperEstate.Areas.Admin.Service
{
    public interface IAgentService
    {
        Task<List<ResultAgentDto>> GetAllAgentListAsync();
    }
}
