using Microsoft.Extensions.DependencyInjection;

namespace CA.MigratorDB
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            /* Inyectamos la clase 'App' */
            services.AddSingleton<App>();

            /* Otros servicios de la aplicación de la consola. */
            //services.AddTransient<IUser, User>();

            return services;
        }
    }
}
