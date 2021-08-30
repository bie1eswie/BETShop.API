using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.ViewModels
{
		public class ShoppingCardView
		{
				public int Id { get; set; }
				public List<CardItemView> CardItems { get; set; }
		}
}
