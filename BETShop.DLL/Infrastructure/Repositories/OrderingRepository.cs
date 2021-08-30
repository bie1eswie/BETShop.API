using BETShop.API.Infrastructure.Repositories.Abstract;
using BETShop.API.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Infrastructure.Repositories
{
		public class OrderingRepository : IOrderingRepository
		{
				private readonly ProductCatalogDbContext _productCatalogDbContext;
				public OrderingRepository(ProductCatalogDbContext productCatalogDbContext)
				{
						_productCatalogDbContext = productCatalogDbContext;
				}
				public async  Task<Order> Add(Order order)
				{
						_productCatalogDbContext.Orders.Add(order);
						await	_productCatalogDbContext.SaveChangesAsync();
						return order;
				}

				public Task<Order> GetAsync(int orderId)
				{
						throw new NotImplementedException();
				}

				public void Update(Order order)
				{
						throw new NotImplementedException();
				}
		}
}
