using Microsoft.Extensions.Options;
using MultiShop.Catalog.Mapping;
using MultiShop.Catalog.Services.Implementations;
using MultiShop.Catalog.Services.Interfaces;
using MultiShop.Catalog.Settings;
using System.Reflection;

namespace MultiShop.Catalog
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddCatalogServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Servisleri Scoped olarak ekleme
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService, ProductImageService>();

            // AutoMapper Konfigürasyonu
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<GeneralMapping>(); // Profilinizi ekleyin
            }, typeof(Program).Assembly);

            // Database Ayarlarının Konfigürasyonu
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
            services.AddScoped<IDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });

            return services;
        }
    }
}