using BETShop.API.Infrastructure.Repositories.Abstract;
using BETShop.API.Models.ShoppingCardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BETShop.API.Infrastructure.Repositories
{
		public class ShoppingCardRepository : IShoppingCardRepository
		{
				private readonly ProductCatalogDbContext _productCatalogDbContext;

				public ShoppingCardRepository(ProductCatalogDbContext productCatalogDbContext)
				{
						_productCatalogDbContext = productCatalogDbContext;
				}

				public async Task<bool> DeleteShoppingCardtAsync(int shoppingCardId)
				{
						var shoppingCard = _productCatalogDbContext.ShoppingCards.SingleOrDefault(x=>x.Id == shoppingCardId);
						if (shoppingCard != null)
						{
								_productCatalogDbContext.ShoppingCards.Remove(shoppingCard);
								return await _productCatalogDbContext.SaveChangesAsync() > 0;
						}
						return false;
				}

				public async Task<ShoppingCard> GetShoppingCardAsync(int shoppingCardId)
				{
						return await _productCatalogDbContext.ShoppingCards
									 .Include(s => s.CardItems)
									 .SingleOrDefaultAsync(x => x.Id == shoppingCardId);
				}

				public async Task<ShoppingCard> UpdateShoppingCardAsync(ShoppingCard shoppingCard)
				{
						_productCatalogDbContext.ShoppingCards.Update(shoppingCard);
						await _productCatalogDbContext.SaveChangesAsync();
						return shoppingCard;
				}

				public async Task<ShoppingCard> CreateShoppingCardAsync(ShoppingCard shoppingCard)
				{
						var userCard = await _productCatalogDbContext.ShoppingCards.FirstOrDefaultAsync(x => x.UserId == shoppingCard.UserId);
						if (userCard == null)
						{
								_productCatalogDbContext.ShoppingCards.Add(shoppingCard);
								await _productCatalogDbContext.SaveChangesAsync();
								return shoppingCard;
						}
						else
						{
								return userCard;
						}
				}
		}
}
