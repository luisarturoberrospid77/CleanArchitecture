using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using CA.API.Middleware;

namespace CA.Api.ServiceCollection
{
    public static class AppBuilderExtension
    {
        public static void InitConfigurationAPI(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
