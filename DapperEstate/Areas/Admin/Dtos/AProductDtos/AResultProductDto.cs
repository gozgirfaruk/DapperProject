namespace DapperEstate.Areas.Admin.Dtos.AProductDtos
{
	public class AResultProductDto
	{
        public int ProductID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CoverImage { get; set; }
        public string PropType { get; set; }
        public string City { get; set; }
        public bool PropStatus { get; set; }
        public bool Recent { get; set; }
    }
}
