using Dapper;
using DapperEstate.Areas.Admin.Dtos.SliderDtos;
using DapperEstate.Context;

namespace DapperEstate.Areas.Admin.Service
{
	public class AdminSliderService : IAdminSliderService
	{
		private readonly DapperContext _context;

		public AdminSliderService(DapperContext context)
		{
			_context = context;
		}

		public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
		{
			string query = "Insert Into TblSlider (ImageUrl,Header,Address,Description,Price) Values (@p1,@p2,@p3,@p4,@p5)";
			var parameters = new DynamicParameters();
			parameters.Add("@p1",createSliderDto.ImageUrl);
			parameters.Add("@p2",createSliderDto.Header);
			parameters.Add("@p3",createSliderDto.Address);
			parameters.Add("@p4",createSliderDto.Description);
			parameters.Add("@p5",createSliderDto.Price);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);	
		}

		public async Task DeleteSliderAsync(int id)
		{
			string query = "Delete From TblSlider Where SliderID=@p1";
			var parameter = new DynamicParameters();
			parameter.Add("@p1",id); 
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameter);
		}

        public async Task<GetSliderDto> GetByIdSliderAsync(int id)
        {
			string query = "Select * From TblSlider Where SliderID=@p1";
			var parameter=new DynamicParameters();
			parameter.Add("@p1",id );
			var connection = _context.CreateConnection();
		    var values = await connection.QueryFirstOrDefaultAsync<GetSliderDto>(query,parameter);
			return values;
        }

        public async Task<List<ResultSliderDto>> GetSliderListAsync()
		{
			string query = "Select * From TblSlider";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultSliderDto>(query);
			return values.ToList();
		}

		public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
		{
			string query = "Update TblSlider Set ImageUrl=@p1, Header=@p2, Address=@p3, Description=@p4, Price=@p5 where SliderID=@p6";
			var parameters = new DynamicParameters();	
			parameters.Add("@p1",updateSliderDto.ImageUrl);
			parameters.Add("@p2",updateSliderDto.Header);
			parameters.Add("@p3",updateSliderDto.Address);
			parameters.Add("@p4",updateSliderDto.Description);
			parameters.Add("@p5",updateSliderDto.Price);
			parameters.Add("@p6",updateSliderDto.SliderID);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
		}

		
	}
}
