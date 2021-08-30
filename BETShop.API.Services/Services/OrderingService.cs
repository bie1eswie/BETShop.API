using BETShop.API.Infrastructure.Repositories.Abstract;
using BETShop.API.Models.OrderModels;
using BETShop.API.Services.Abstract;
using BETShop.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BETShop.API.Models.ShoppingCardModels;
using AutoMapper;

namespace BETShop.API.Services
{
		public class OrderingService : IOrderingService
		{
				private readonly IOrderingRepository _orderingRepository;
				private readonly IShoppingCardRepository _shoppingCardRepository;
				private readonly IMembershipService _membershipService;

				public OrderingService(IOrderingRepository orderingRepository, IShoppingCardRepository shoppingCardRepository, IMembershipService membershipService)
				{
						_orderingRepository = orderingRepository;
						_shoppingCardRepository = shoppingCardRepository;
						_membershipService = membershipService;
				}
				public async Task<Order> CheckOut(ShoppingCardView  shoppingCardView)
				{

						if (shoppingCardView == null)
						{
								return null;
						}
						var orderItems = new List<OrderItem>();
						foreach (var item in shoppingCardView.CardItems)
						{
								OrderItem orderItem = new OrderItem(item.Price, item.Quantity, item.ProductId);
								orderItems.Add(orderItem);
						}
						var subTotal = orderItems.Sum(item => item.Price * item.Quantity);

						var currentUser = await _membershipService.GetCurrentUserId();
						var order = new Order(orderItems, currentUser, subTotal);
						await _orderingRepository.Add(order);
						await _shoppingCardRepository.DeleteShoppingCardtAsync(shoppingCardView.Id);
						return order;
				}
		}
}