using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersAssignment.Filters;

public class JsonResultFilter : IResultFilter
{
    private readonly ILogger<JsonResultFilter> _logger; 
    public JsonResultFilter(ILogger<JsonResultFilter> logger)
    {
        _logger = logger;   
    }
    public void OnResultExecuting(ResultExecutingContext context)
    {
        context.HttpContext.Response.Headers.Add("X-Custom-Header", "Filtered");
    }

    public void OnResultExecuted(ResultExecutedContext context) 
    {
        _logger.LogInformation("Response ststus code: {StatusCode}", context.HttpContext.Response.StatusCode);
    }
}