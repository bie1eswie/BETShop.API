using BETShop.API.Models.OrderModels;
using BETShop.API.Services.Abstract;
using BETShop.API.Utilities;
using BETShop.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Services
{
		public class NotificationService : INotificationService
		{
				private readonly IEmailService _emailService;

				public NotificationService(IEmailService emailService)
				{
						_emailService = emailService;
				}
				public async Task<bool> SendOrderNotification(ShoppingCardView shoppingCardView,int orderID, string userEmail)
				{
						var message = HelperMethods.CreateOrberTemplate(shoppingCardView,orderID);
						return await _emailService.SendEmailAsync(userEmail, Constants.PURCHASE_ORDER_EMAIL_SUBJECT, message);
				}
		}
}
