using BETShop.API.Models.OrderModels;
using BETShop.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BETShop.API.Utilities
{
		public static class HelperMethods
		{
				public static string CreateOrberTemplate(ShoppingCardView  shoppingCardView,int orderID)
				{
						StringBuilder messageBuilder = new StringBuilder();
						messageBuilder.Append($"<h2>Hi there please find details of your order #{orderID} below</h2>");
						messageBuilder.Append(@"<table>
								<tbody><tr>
									<th>Product</th>
									<th></th>
									<th>Price</th>
									<th>Quantity</th>
									<th>Total</th></tr>");
						foreach (var item in shoppingCardView.CardItems)
						{
								var itemRow = $"<tr><td><div><img src = '{item.PictureUrl }' alt='{item.Name}'></div></td><td>{item.Name }</td><td>{item.Price}</td><td><div><div><i></i></div><input type='number' name='num-product1' value='{item.Quantity}'><div><i></i></div></div></td><td>{ item.Quantity * item.Price}</td></tr>";

								messageBuilder.Append(itemRow);
						}
						messageBuilder.Append("</tbody></table>");
						return messageBuilder.ToString();
				}
		}
}
