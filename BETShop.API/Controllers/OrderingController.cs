using AutoMapper;
using BETShop.API.Infrastructure.Logging;
using BETShop.API.Models.OrderModels;
using BETShop.API.Models.ShoppingCardModels;
using BETShop.API.Services.Abstract;
using BETShop.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BETShop.API.Controllers
{
	  [Authorize]
		public class OrderingController : BaseController
		{
				private readonly IOrderingService _orderingService;
				private readonly ILoggerManager _logger;
				private readonly INotificationService _notificationService;
				private readonly IMapper _mapper;
				public OrderingController(IOrderingService orderingService, ILoggerManager logger, INotificationService notificationService, IMapper mapper)
				{
						_orderingService = orderingService;
						_logger = logger;
						_notificationService = notificationService;
						_mapper = mapper;
				}

				[HttpPost]
				public async Task<ActionResult<Order>> CheckOut(ShoppingCardView shoppingCard)
				{
						try
						{
								var newOrder = await _orderingService.CheckOut(shoppingCard);
								if (newOrder == null)
								{
										return BadRequest("Error while processing your order");
								}

								var currentUserEmail = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
								//if we manage to get to this point then we can send the email;
								await _notificationService.SendOrderNotification(shoppingCard, newOrder.Id, currentUserEmail);
								return newOrder;
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return BadRequest();
						}
				}
		}
}
