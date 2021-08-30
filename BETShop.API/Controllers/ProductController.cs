using BETShop.API.Infrastructure.Logging;
using BETShop.API.Infrastructure.Repositories.Abstract;
using BETShop.API.Services;
using BETShop.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Controllers
{
		public class ProductController : BaseController
		{
				private readonly IProductRepository _productRepository;
				private readonly ILoggerManager _logger;

				public ProductController(IProductRepository productRepository, ILoggerManager logger)
				{
						_productRepository = productRepository;
						_logger = logger;
				}

				[HttpGet]
				public async Task<ActionResult<ProductPageView>> GetProducts([FromQuery] ProductSearchCriteria productSearchCriteria)
				{
						try
						{
								return await _productRepository.GetProductsPage(productSearchCriteria.PageSize, productSearchCriteria.PageIndex);
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return BadRequest(ex);
						}
				}
		}
}
