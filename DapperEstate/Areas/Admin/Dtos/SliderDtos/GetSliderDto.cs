using System.Web.Mvc;

namespace DapperEstate.Areas.Admin.Dtos.SliderDtos
{
    public class GetSliderDto
    {
        public int SliderID { get; set; }
        public string Header { get; set; }
        public string Decimal { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
