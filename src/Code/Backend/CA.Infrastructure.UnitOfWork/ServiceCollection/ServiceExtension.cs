using Microsoft.Extensions.DependencyInjection;

using CA.Domain.Interfaces.Base;
using CA.Infrastructure.UnitOfWork.Base;
using CA.Infrastructure.Persistence.Data;

namespace CA.Infrastructure.UnitOfWork.ServiceCollection
{
    public static class ServiceExtension
    {
        public static void AddUnitOfWorkLayer(this IServiceCollection services)
        {
            /* Factory y Unit Of Work. */
            services.AddScoped<IDbFactory<PatosaDbContext>, DbFactory<PatosaDbContext>>();
            services.AddScoped<IUnitOfWork<PatosaDbContext>, UnitOfWork<PatosaDbContext>>();
        }
    }
}
