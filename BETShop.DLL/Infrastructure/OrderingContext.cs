using BETShop.API.Models.OrderModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Infrastructure
{
		public class OrderingContext : DbContext
		{
				public DbSet<Order> Orders { get; set; }
				public DbSet<OrderItem> OrderItems { get; set; }
		}
}
