namespace DapperEstate.Areas.Admin.Dtos.AProductDtos
{
	public class ACreateProductDto
	{
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int PropID { get; set; }
        public int LocationID { get; set; }
        public int AgentID { get; set; }
        public bool PropStatus { get; set; }
        public bool Recent { get; set; }
        public string CoverImage { get; set; }
        public string Description2 { get; set; }
        public string VideoUrl { get; set; }

    }
}
