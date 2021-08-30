using BETShop.API.Infrastructure.Repositories.Abstract;
using BETShop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BETShop.API.ViewModels;
using AutoMapper;

namespace BETShop.API.Infrastructure.Repositories
{
		public class ProductRepository : IProductRepository
		{

				private readonly ProductCatalogDbContext _productCatalogDbContext;
				private readonly IMapper _mapper;
				public ProductRepository(ProductCatalogDbContext productCatalogDbContext, IMapper mapper)
				{
						_productCatalogDbContext = productCatalogDbContext;
						_mapper = mapper;
				}
				public async Task<ProductView> GetProductByIdAsync(int id)
				{
						var product = await _productCatalogDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
						return _mapper.Map<Product, ProductView>(product);
				}

				public async Task<ProductPageView> GetProductsPage(int pageSize = 10, int pageIndex = 0)
				{
						var totalItems = await _productCatalogDbContext.Products.LongCountAsync();

						var itemsOnPage = await _productCatalogDbContext.Products
								.OrderBy(c => c.Name)
								.Skip(pageSize * pageIndex)
								.Take(pageSize)
								.ToListAsync();

						var productViewsOnPage = _mapper.Map<List<Product>, IEnumerable<ProductView>>(itemsOnPage);
						var currentPage = new ProductPageView(pageIndex, pageSize, totalItems, productViewsOnPage);
						return currentPage;
				}
		}
}
