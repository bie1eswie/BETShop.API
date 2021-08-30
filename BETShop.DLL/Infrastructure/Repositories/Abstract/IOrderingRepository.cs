using BETShop.API.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Infrastructure.Repositories.Abstract
{
		public interface IOrderingRepository
		{
				Task<Order> Add(Order order);
				void Update(Order order);
				Task<Order> GetAsync(int orderId);
		}
}
