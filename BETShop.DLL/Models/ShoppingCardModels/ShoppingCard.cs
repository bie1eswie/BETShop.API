using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Models.ShoppingCardModels
{
		public class ShoppingCard : BaseModel
		{
				public string UserId { get; set; }
				public List<CardItem> CardItems { get; set; }

				public ShoppingCard()
				{
						CardItems = new List<CardItem>();
				}
		}
}
