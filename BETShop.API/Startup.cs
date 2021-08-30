using BETShop.API.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BETShop.API.Extensions;
using AutoMapper;
using BETShop.API.Utilities;
using System.IO;
using NLog;
using BETShop.API.Utilities.Settings;
using BETShop.Utilities;

namespace BETShop.API
{
		public class Startup
		{
				public Startup(IConfiguration configuration)
				{
						Configuration = configuration;
						LogManager.LoadConfiguration(System.String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
				}

				public IConfiguration Configuration { get; }

				// This method gets called by the runtime. Use this method to add services to the container.
				public void ConfigureServices(IServiceCollection services)
				{

						services.AddControllers();
						services.AddAutoMapper(typeof(AutoMapperProfile));
						services.AddDbContext<BETShopIdentityDbContext>(options =>
										options.UseSqlServer(Configuration["ConnectionString"],
										sqlServerOptionsAction: sqlOptions =>
										{
												sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
												sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
										}));

						services.AddDbContext<ProductCatalogDbContext>(options =>
										options.UseSqlServer(Configuration["ConnectionString"],
										sqlServerOptionsAction: sqlOptions =>
										{
												sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
												sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
										}));
						services.AddServiceDependencies();
						services.AddIdentityServices(Configuration);
						services.AddSwaggerDoc();
						services.Configure<AppSettings>(opt => Configuration.GetSection("AppSettings").Bind(opt));
						services.AddCors(options =>
						{
								options.AddPolicy("CorsPolicy", policy =>
								{
										policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
								});
						});

				}

				// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
				public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
				{
						if (env.IsDevelopment())
						{
								app.UseDeveloperExceptionPage();
								app.UseSwagger();
								app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BETShop.API v1"));
						}

						app.UseHttpsRedirection();

						app.UseRouting();

						app.UseCors("CorsPolicy");

						app.UseAuthentication();

						app.UseAuthorization();

						app.UseDeveloperExceptionPage();

						app.UseEndpoints(endpoints =>
						{
								endpoints.MapControllers();
						});
				}
		}
}
