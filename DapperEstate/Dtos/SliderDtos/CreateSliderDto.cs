namespace DapperEstate.Dtos.SliderDtos
{
    public class CreateSliderDto
    {
        public string ImageUrl { get; set; }
        public string Header { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
