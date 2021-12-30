using Microsoft.Extensions.DependencyInjection;

using CA.Core.Interfaces.Base;
using CA.Core.Interfaces.Services;
using CA.Core.Interfaces.Repository;

using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Base;
using CA.Infrastructure.Persistence.Services;
using CA.Infrastructure.Persistence.Repository;

namespace CA.Infrastructure.Extensions.ServiceCollection
{
  public static class IoC
  {
    public static IServiceCollection AddDependency(this IServiceCollection services)
    {
      /* Factory y Unit Of Work. */
      services.AddScoped<IDbFactory<PatosaDbContext>, DbFactory<PatosaDbContext>>();
      services.AddScoped<IUnitOfWork<PatosaDbContext>, UnitOfWork<PatosaDbContext>>();

      /* Repositorios. */
      services.AddTransient<IArticleRepository<PatosaDbContext>, ArticleRepository>();
      services.AddTransient<IStoreRepository<PatosaDbContext>, StoreRepository>();
      services.AddTransient<IBrandRepository<PatosaDbContext>, BrandRepository>();
      services.AddTransient<ISupplierRepository<PatosaDbContext>, SupplierRepository>();
      services.AddTransient<ICategoryRepository<PatosaDbContext>, CategoryRepository>();
      services.AddTransient<IMenuRepository<PatosaDbContext>, MenuRepository>();

      /* Servicios. */
      services.AddTransient<IArticleService, ArticleService>();
      services.AddTransient<IStoreService, StoreService>();
      services.AddTransient<IBrandService, BrandService>();
      services.AddTransient<ISupplierService, SupplierService>();
      services.AddTransient<ICategoryService, CategoryService>();
      services.AddTransient<IMenuService, MenuService>();

      return services;
    }
  }
}
