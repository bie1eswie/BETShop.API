using BETShop.API.Models;
using BETShop.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Infrastructure.Repositories.Abstract
{
		public interface IProductRepository
		{
				Task<ProductView> GetProductByIdAsync(int id);
				Task<ProductPageView> GetProductsPage(int pageSize = 10, int pageIndex = 0);
				Task<bool> IsProductInStock(int productID);
				Task UpdateProductQuantity(int productId, int quantity);
		}
}
