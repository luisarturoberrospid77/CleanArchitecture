using System.Reflection;

using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

using CA.Application.Beheaviours;

namespace CA.Application.ServiceCollection
{
  public static class ServiceExtension
  {
    public static void AddApplicationLayer(this IServiceCollection services)
    {
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
      services.AddMediatR(Assembly.GetExecutingAssembly());
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }
  }
}
