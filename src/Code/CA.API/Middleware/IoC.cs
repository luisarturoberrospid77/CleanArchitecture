using Microsoft.Extensions.DependencyInjection;

using CA.Core.Interfaces;
using CA.Infrastructure.Repositories;

namespace CA.Api
{
  public static class IoC
  {
    public static IServiceCollection AddDependency(this IServiceCollection services)
    {
      // services.AddScoped<IMyService, MyService>();
      services.AddTransient<IArticleRepository, ArticleRepository>();
      services.AddTransient<IStoreRepository, StoreRepository>();
      services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
      return services;
    }
  }
}
