using System.Reflection;

using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

using CA.Infrastructure.Filters;

namespace CA.Infrastructure.Extensions.ServiceCollection
{
  public static class CtrlCfg
  {
    public static IServiceCollection AddControllersExtend(this IServiceCollection services)
    {
      services.AddControllers(options =>
      {
        options.Filters.Add<GlobalValidationFilterAttribute>();
      }).ConfigureApiBehaviorOptions(options => {
        options.SuppressModelStateInvalidFilter = true;
      }).AddNewtonsoftJson(options => {       
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;       
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
        options.SerializerSettings.FloatFormatHandling = Newtonsoft.Json.FloatFormatHandling.DefaultValue;
        options.SerializerSettings.FloatParseHandling = Newtonsoft.Json.FloatParseHandling.Decimal;
        options.UseCamelCasing(false);
      }).AddFluentValidation(options => {
        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
      });
      return services;
    }
  }
}
