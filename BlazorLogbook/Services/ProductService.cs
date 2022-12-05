using System;
using BlazorLogbook.Models;
namespace BlazorLogbook.Services
{
	public class ProductService
	{
		public static readonly List<Product> Products = new List<Product>()
		{
			new()
			{
				Id=1,
				Name = "iPhone 11",
				Description = "Version 11 of the Apple iPhone",
				Price = 500
			},

            new()
            {
                Id=2,
                Name = "iPhone 12",
                Description = "Version 12 of the Apple iPhone",
                Price = 600
            },

            new()
            {
                Id=3,
                Name = "iPhone 13",
                Description = "Version 13 of the Apple iPhone",
                Price = 700
            },

            new()
            {
                Id=4,
                Name = "iPhone 14",
                Description = "Version 14 of the Apple iPhone",
                Price = 800
            },
        };
	}
}

