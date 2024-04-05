using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BomNegocio.API.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;
        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger) 
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu uma exceção não tratada: status code 500 aqui");

            context.Result = new ObjectResult("Ocorreu um problema ao tratar a sua solicitação: Status Code 500 aqui2")
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
