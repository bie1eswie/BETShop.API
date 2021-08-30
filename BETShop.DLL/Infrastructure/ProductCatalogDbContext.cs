using BETShop.API.Models;
using BETShop.API.Models.OrderModels;
using BETShop.API.Models.ShoppingCardModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Infrastructure
{
		public class ProductCatalogDbContext : DbContext
		{
				public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options) : base(options)
				{

				}

				protected override void OnModelCreating(ModelBuilder modelBuilder)
				{
						base.OnModelCreating(modelBuilder);
						modelBuilder.Entity<Product>()
								.Property(p => p.Price)
								.HasColumnType("decimal(18,4)");

						modelBuilder.Entity<Order>()
		.Property(p => p.Subtotal)
		.HasColumnType("decimal(18,4)");
						modelBuilder.Entity<OrderItem>()
		.Property(p => p.Price)
		.HasColumnType("decimal(18,4)");
				}
				public DbSet<Product> Products { get; set; }
				public DbSet<Order> Orders { get; set; }
				public DbSet<OrderItem> OrderItems { get; set; }
				public DbSet<CardItem> CardItems { get; set; }
				public DbSet<ShoppingCard> ShoppingCards { get; set; }
		}
}
