namespace DapperEstate.Dtos.ProductDtos
{
    public class CreateSearchDto
    {
		public string Title { get; set; }
		public decimal Price { get; set; }
        public string PropStatus { get; set; }
        public int PropID { get; set; }
		public int	LocationID{ get; set; }
        public int AgentID{ get; set; }
    }
}
