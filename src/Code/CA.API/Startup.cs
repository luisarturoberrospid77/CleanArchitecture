using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using CA.Core.Interfaces;
using CA.Infrastructure.Data;
using CA.Infrastructure.Repositories;

namespace CA.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      /* Añadir controllers. */
      services.AddControllers();

      /* Cadena de conexión al contexto de Base de Datos. */
      services.AddDbContext<PatosaDbContext>(options => {
        options.UseSqlServer(Configuration.GetConnectionString("PatosaDbContext"));
      });

      /* Contenedor de inversión de control (IoC) => Middleware. */
      IoC.AddDependency(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
