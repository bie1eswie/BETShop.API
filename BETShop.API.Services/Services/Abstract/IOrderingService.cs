using BETShop.API.Models.OrderModels;
using BETShop.API.Models.ShoppingCardModels;
using BETShop.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Services.Abstract
{
		public interface IOrderingService
		{
				Task<Order> CheckOut(ShoppingCardView shoppingCard);
		}
}
