using Dapper;
using DapperEstate.Areas.Admin.Dtos.AAgentDtos;
using DapperEstate.Context;

namespace DapperEstate.Areas.Admin.Service
{
    public class AgentService : IAgentService
    {
        private readonly DapperContext _context;

        public AgentService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultAgentDto>> GetAllAgentListAsync()
        {
            string query = "Select * From TblAgent";
            var connection= _context.CreateConnection();
            var values = await connection.QueryAsync<ResultAgentDto>(query);
            return values.ToList();
        }
    }
}
