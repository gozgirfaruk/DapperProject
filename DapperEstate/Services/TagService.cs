using Dapper;
using DapperEstate.Context;
using DapperEstate.Dtos.TagDtos;

namespace DapperEstate.Services
{
    public class TagService : ITagService
    {
        private readonly DapperContext _context;

        public TagService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultTagByProductDto>> TagListByProductAsync(int id)
        {
            string query = $"Select * From TblTags Where ProductID ={id}";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultTagByProductDto>(query);
            return values.ToList();
        }
    }
}
