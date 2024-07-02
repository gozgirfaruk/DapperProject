namespace DapperEstate.Dtos.ProductDtos
{
    public class CreateSearchDto
    {
		public int ProductID { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
		public string Description2 { get; set; }
		public string CoverImage { get; set; }
        public string PropStatus { get; set; }
        public int PropID { get; set; }
		public int	LocationID{ get; set; }
        public string City { get; set; }
        public int AgentID{ get; set; }
        public string NameSurname { get; set; }
    }
}
