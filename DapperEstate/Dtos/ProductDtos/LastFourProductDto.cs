﻿namespace DapperEstate.Dtos.ProductDtos
{
	public class LastFourProductDto
	{
		public int ProductID { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
		public string CoverImage { get; set; }
        public string PropType { get; set; }
		public bool PropStatus { get; set; }
        public string City { get; set; }
    }
}
