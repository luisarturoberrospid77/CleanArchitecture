using Microsoft.Extensions.DependencyInjection;

using CA.Core.Interfaces;
using CA.Infrastructure.Repositories;

namespace CA.Infrastructure.Extensions.ServiceCollection
{
  public static class IoC
  {
    public static IServiceCollection AddDependency(this IServiceCollection services)
    {
      // services.AddScoped<IMyService, MyService>();
      // services.AddScoped<GlobalValidationFilterAttribute>();
      services.AddTransient<IArticleRepository, ArticleRepository>();
      services.AddTransient<IStoreRepository, StoreRepository>();
      services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
      return services;
    }
  }
}
