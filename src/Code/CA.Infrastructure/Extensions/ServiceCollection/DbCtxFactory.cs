using System;

using Microsoft.Extensions.DependencyInjection;

using CA.Infrastructure.Persistence.Data;

namespace CA.Infrastructure.Extensions.ServiceCollection
{
  public static class DbCtxFactory
  {
    public static IServiceCollection AddDbFactory(this IServiceCollection services)
    {
      services.AddScoped<Func<PatosaDbContext>>((provider) => () => provider.GetService<PatosaDbContext>());

      /* Agregar aquí las implementaciones de Factory Pattern, asociadas a cada conexto de Base de Datos... */
      return services;
    }
  }
}
