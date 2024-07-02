using System.Web.Mvc;

namespace DapperEstate.Areas.Admin.Dtos.SliderDtos
{
	public class CreateSliderDto
	{
        public string Header { get; set; }
        public string Decimal { get; set; }
        public string Address { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

    }
}
