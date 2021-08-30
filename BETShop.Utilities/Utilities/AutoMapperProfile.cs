using AutoMapper;
using BETShop.API.Models;
using BETShop.API.Models.ShoppingCardModels;
using BETShop.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.Utilities
{
		public class AutoMapperProfile : Profile
		{
				public AutoMapperProfile()
				{
						CreateMap<Product, ProductView>();
						CreateMap<ShoppingCard, ShoppingCardView>();
						CreateMap<CardItem, CardItemView>();
						CreateMap<CardItem, Product>().ForMember(d => d.Id, o => o.MapFrom(s => s.ProductId));
				}
		}
}
