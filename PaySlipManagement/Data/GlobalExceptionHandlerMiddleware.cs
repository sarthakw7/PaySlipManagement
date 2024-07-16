using System.Net;

namespace PaySlipManagement.API.Data
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
        private readonly IExceptionLoggerService _exceptionLoggerService;

        public GlobalExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionHandlerMiddleware> logger,
            IExceptionLoggerService exceptionLoggerService)
        {
            _next = next;
            _logger = logger;
            _exceptionLoggerService = exceptionLoggerService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred.");

            await _exceptionLoggerService.LogExceptionAsync(exception);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = "An error occurred while processing your request."
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }

    }
}
