using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CA.Infrastructure.Persistence.Data;

namespace CA.Infrastructure.Persistence.ServiceCollection
{
    public static class ServiceExtension
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            /* Contextos de Bases de Datos. */
            services.AddDbContext<PatosaDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("PatosaDbContext")); });

            /* DbFactory pattern. */
            /* Agregar aquí las implementaciones de Factory Pattern, asociadas a cada conexto de Base de Datos... */
            services.AddScoped<Func<PatosaDbContext>>((provider) => () => provider.GetService<PatosaDbContext>());
        }
    }
}
