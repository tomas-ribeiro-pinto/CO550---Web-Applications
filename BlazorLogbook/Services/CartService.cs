using System;
using System.Linq;
using BlazorLogbook.Models;

namespace BlazorLogbook.Services
{
	public class CartService
	{
		public static List<ShoppingItem> SelectedItems { get; set; } = new List<ShoppingItem>();

		public void AddProductToCart(int productId)
		{

			if (!ProductInCart(productId))
			{
                var product = ProductService.Products.First(p => p.Id == productId);

                ShoppingItem item = new ShoppingItem();
                item.Product = product;
                item.PurchasePrice = product.Price;
                SelectedItems.Add(item);
			}
		}

		public bool ProductInCart(int productId)
		{
			foreach (ShoppingItem item in SelectedItems)
			{
				if (item.Product.Id == productId)
				{
					item.Quantity++;
					return true;
				}
			}
            return false;
        }
	}
}

