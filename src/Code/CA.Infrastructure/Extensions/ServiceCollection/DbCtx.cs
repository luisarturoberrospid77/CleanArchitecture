using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CA.Infrastructure.Data;

namespace CA.Infrastructure.Extensions.ServiceCollection
{
  public static class DbCtx
  {
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<PatosaDbContext>(options => {
        options.UseSqlServer(configuration.GetConnectionString("PatosaDbContext"));
      });
      return services;
    }
  }
}
