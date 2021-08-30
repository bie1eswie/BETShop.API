using BETShop.API.Infrastructure.Logging;
using BETShop.API.Infrastructure.Repositories;
using BETShop.API.Infrastructure.Repositories.Abstract;
using BETShop.API.Services;
using BETShop.API.Services.Abstract;
using BETShopAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Extensions
{
		public static class DependencyInjectionExtention
		{
				public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
				{
						services.AddHttpContextAccessor();
						services.AddTransient<IMembershipService, MembershipService>();
						services.AddScoped<IAuthTokenService, AuthTokenService>();
						services.AddScoped<IProductRepository, ProductRepository>();
						services.AddScoped<IOrderingRepository, OrderingRepository>();
						services.AddScoped<IOrderingService, OrderingService>();
						services.AddSingleton<IEmailService, EmailService>();
						services.AddScoped<INotificationService, NotificationService>();
						services.AddScoped<IShoppingCardRepository, ShoppingCardRepository>();
						services.AddSingleton<ILoggerManager, LoggerManager>();
						return services;
				}
		}
}
