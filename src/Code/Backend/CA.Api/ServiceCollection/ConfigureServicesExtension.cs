using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CA.Application.ServiceCollection;
using CA.Infrastructure.Common.ServiceCollection;
using CA.Infrastructure.UnitOfWork.ServiceCollection;
using CA.Infrastructure.Persistence.ServiceCollection;

using CA.API.Middleware;

namespace CA.Api.ServiceCollection
{
  public static class ConfigureServicesExtension
  {
    public static void InitConfigurationAPI(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddApplicationLayer();
      services.AddPersistenceLayer(configuration);
      services.AddUnitOfWorkLayer();
      services.AddCommonLayer();
      services.AddTransient<ErrorHandlerMiddleware>();
      services.AddControllers().AddNewtonsoftJson(options =>
      {
        options.UseCamelCasing(true);
        options.SerializerSettings.Culture = System.Globalization.CultureInfo.CurrentCulture;
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
        options.SerializerSettings.FloatFormatHandling = Newtonsoft.Json.FloatFormatHandling.DefaultValue;
        options.SerializerSettings.FloatParseHandling = Newtonsoft.Json.FloatParseHandling.Decimal;
      });
    }
  }
}
