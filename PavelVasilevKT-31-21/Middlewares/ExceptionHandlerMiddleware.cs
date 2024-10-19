using System;

namespace PavelVasilevKT_31_21.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError($"Ошибка! : {e.Message}");

                var httpResponse = context.Response;

                //var responseModel = new ResponseModel<object>
                //{
                //    Succeeded = false,
                //    Message = exception.Message
                //};

                throw;
            }
        }
    }
}
