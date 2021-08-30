using AutoMapper;
using BETShop.API.Infrastructure.Logging;
using BETShop.API.Infrastructure.Repositories;
using BETShop.API.Infrastructure.Repositories.Abstract;
using BETShop.API.Models.ShoppingCardModels;
using BETShop.API.Services;
using BETShop.API.Services.Abstract;
using BETShop.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BETShop.API.Controllers
{
		[Authorize]
		public class ShoppingCardController : BaseController
		{
				private readonly IShoppingCardRepository _shoppingCardRepository;
				private readonly IMapper _mapper;
				private IMembershipService _membershipService;
				private readonly ILoggerManager _logger;
				public ShoppingCardController(IShoppingCardRepository shoppingCardRepository, IMapper mapper, IMembershipService membershipService, ILoggerManager logger)
				{
						_shoppingCardRepository = shoppingCardRepository;
						_mapper = mapper;
						_membershipService = membershipService;
						_logger = logger;
				}

				[HttpGet("{id}")]
				public async Task<ActionResult<ShoppingCardView>> GetBasketById(int id)
				{
						try
						{
								var shoppingCard = await _shoppingCardRepository.GetShoppingCardAsync(id);
								if (shoppingCard == null)
										return BadRequest();
								return Ok(shoppingCard);
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return BadRequest(ex);
						}
				}

				[HttpPut]
				public async Task<ActionResult<ShoppingCardView>> UpdateShoppingCard(ShoppingCardView shoppingCardView)
				{
						try
						{
								var shoppingCardMap = _mapper.Map<ShoppingCardView, ShoppingCard>(shoppingCardView);
								var shoppingCard = await _shoppingCardRepository.UpdateShoppingCardAsync(shoppingCardMap);
								return Ok(shoppingCard);
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return BadRequest(ex);
						}
				}

				[HttpGet]
				public async Task<ActionResult<ShoppingCardView>> CreateShoppingCard()
				{
						try
						{
								var http = HttpContext.User;
								var currentUser = await _membershipService.GetCurrentUserId();
								var shoppingCard = await _shoppingCardRepository.CreateShoppingCardAsync(new ShoppingCard() { UserId = currentUser });
								return Ok(shoppingCard);
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return BadRequest(ex);
						}
				}
		}
}
