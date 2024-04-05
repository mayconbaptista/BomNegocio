using Microsoft.AspNetCore.Mvc.Filters;

namespace BomNegocio.API.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        public readonly ILogger<ApiLoggingFilter> _Logger;

        public ApiLoggingFilter (ILogger<ApiLoggingFilter> logger)
        {
            _Logger = logger;
        }

        // executa entes
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _Logger.LogInformation("### Executando -> OnActionExecuted");
            _Logger.LogInformation("###################################");
            _Logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _Logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
        }

        // executa depois
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _Logger.LogInformation("### Executando -> OnActionExecuting");
            _Logger.LogInformation("##########################################################");
            _Logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _Logger.LogInformation($"Status code: {context.HttpContext.Response.StatusCode}");
            _Logger.LogInformation("#########################################################");
        }
    }
}
