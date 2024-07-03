namespace DapperEstate.Models
{
	public class SearchPropertyViewModel
	{
        public string Location { get; set; }
        public int  PropID { get; set; }
        public int  AgentID { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
