using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FiltersAssignment.Filters;

public class LoggingFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Debug.WriteLine($"Action {context.ActionDescriptor.DisplayName} is executing");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Debug.WriteLine($"Action {context.ActionDescriptor.DisplayName} executed");
    }
}

