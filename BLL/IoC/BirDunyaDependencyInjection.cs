using BLL.Abstract;
using BLL.Concrete;
using DAL.Abstract;
using DAL.Concrete;
using DAL.EntityFramework.Context;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.IoC
{
    public static class BirDunyaDependencyInjection
    {
        public static IServiceCollection IoCServices(this IServiceCollection services)
        {
            services.AddDbContext<BirDunyaDbContext>();

            services.AddScoped<IDatabaseLoggerDAL, EfDatabaseloggerRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EfCategoryRepository>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDAL, EfProductRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EfCategoryRepository>();

            services.AddScoped<IMasterCategoryService, MasterCategoryManager>();
            services.AddScoped<IMasterCategoryDAL, EfMasterCategoryRepository>();

            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<IBasketDAL, EfBasketRepository>();

            return services;
        }
    }
}
