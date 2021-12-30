using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CA.Infrastructure.Mappings;
using CA.Infrastructure.Extensions.ServiceCollection;
using CA.Infrastructure.Extensions.ApplicationBuilder;

namespace CA.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration) => Configuration = configuration;
    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      /* Añadimos "AutoMapper" antes de configurar los controllers y se cargan todas la configuraciones de
       * AutoMapper en las referencias de este ensamblado. */
      /* services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); */
      /* Otra forma */
      services.AddAutoMapper(typeof(Startup).Assembly, typeof(AutoMapperProfile).Assembly);

      /* Añadir controllers y configurando JSON para evitar referencias circulares, ignorando atributos nulos y 
       * formateando los atributos en notación "CamelCase", así como ajustando la zona horaria a meridiano local. */
      CtrlCfg.AddControllersExtend(services);

      /* Cadena de conexión al contexto de Base de Datos. */
      DbCtx.AddDbContexts(services, Configuration);

      /* Implementaciones del tipo Factory. */
      DbCtxFactory.AddDbFactory(services);

      /* Contenedor de inversión de control (IoC) => Middleware. */
      IoC.AddDependency(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      DefaultCfg.InitConfigurationAPI(app, env);
    }
  }
}
