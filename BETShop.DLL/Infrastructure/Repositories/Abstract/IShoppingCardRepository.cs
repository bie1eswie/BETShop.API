using BETShop.API.Models.ShoppingCardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Infrastructure.Repositories.Abstract
{
		public interface IShoppingCardRepository
		{
				Task<ShoppingCard> GetShoppingCardAsync(int shoppingCardId);
				Task<ShoppingCard> UpdateShoppingCardAsync(ShoppingCard shoppingCard);
				Task<bool> DeleteShoppingCardtAsync(int shoppingCardId);
				Task<ShoppingCard> CreateShoppingCardAsync(ShoppingCard shoppingCard);
		}
}
