using BETShop.API.Models.OrderModels;
using BETShop.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Services.Abstract
{
		public interface INotificationService
		{
				Task<bool> SendOrderNotification(ShoppingCardView shoppingCardView, int orderID, string userEmail);
		}
}
