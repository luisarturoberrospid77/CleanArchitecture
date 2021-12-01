using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CA.Infrastructure.Filters
{
  public class GlobalValidationFilterAttribute : IAsyncActionFilter
  {
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      if (context.ActionArguments.Any(x => x.Value == null))
        context.Result = new BadRequestObjectResult("Object is null");

      if (!context.ModelState.IsValid)
      {
        context.Result = new BadRequestObjectResult(context.ModelState);
        return;
      }

      await next();
    }
  }
}
