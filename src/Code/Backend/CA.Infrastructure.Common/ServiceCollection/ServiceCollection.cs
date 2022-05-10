using Microsoft.Extensions.DependencyInjection;
using CA.Domain.Interfaces.Repository;

using Microsoft.AspNetCore.Http;

using CA.Domain.Interfaces.Services;
using CA.Domain.Interfaces.Management;
using CA.Infrastructure.Common.Helpers;
using CA.Infrastructure.Common.Services;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Common.Repositories;

namespace CA.Infrastructure.Common.ServiceCollection
{
    public static class ServiceCollection
    {
        public static void AddCommonLayer(this IServiceCollection services)
        {
            /* Repositorios. */
            services.AddTransient<IArticleRepository<PatosaDbContext>, ArticleRepository>();
            services.AddTransient<IStoreRepository<PatosaDbContext>, StoreRepository>();
            services.AddTransient<IBrandRepository<PatosaDbContext>, BrandRepository>();
            services.AddTransient<ISupplierRepository<PatosaDbContext>, SupplierRepository>();
            services.AddTransient<ICategoryRepository<PatosaDbContext>, CategoryRepository>();
            services.AddTransient<IMenuRepository<PatosaDbContext>, MenuRepository>();
            services.AddTransient<ICodeValueRepository<PatosaDbContext>, CodeValueRepository>();
            services.AddTransient<ICodeNameSpaceRepository<PatosaDbContext>, CodeNameSpaceRepository>();
            services.AddTransient<IMovementArticleRepository<PatosaDbContext>, MovementArticleRepository>();
            services.AddTransient<IStockArticleRepository<PatosaDbContext>, StockArticleRepository>();
            services.AddTransient<ICustomerRepository<PatosaDbContext>, CustomerRepository>();
            services.AddTransient<ICountryRepository<PatosaDbContext>, CountryRepository>();
            services.AddTransient<ICountryDetailRepository<PatosaDbContext>, CountryDetailRepository>();

            /* Servicios. */
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<ICodeValueService, CodeValueService>();
            services.AddTransient<ICodeNameSpaceService, CodeNameSpaceService>();
            services.AddTransient<IMovementArticleService, MovementArticleService>();
            services.AddTransient<IStockArticleService, StockArticleService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICountryDetailService, CountryDetailService>();

            /* Helpers */
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
            services.AddScoped(typeof(IDataShapeHelper<>), typeof(DataShapeHelper<>));
            services.AddScoped<IModelHelper, ModelHelper>();
        }
    }
}
