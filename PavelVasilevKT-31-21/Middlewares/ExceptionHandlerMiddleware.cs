using System;
using System.Net;

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
                httpResponse.ContentType = "application/json";

                var responseModel = new ResponseModel<object>
                {
                    Successed = false,
                    Message = e.Message
                };

                switch (e)
                {
                    default:
                        httpResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Errors = new List<string>
                        {
                            e.InnerException?.Message
                        };
                        break;
                }

                await httpResponse.WriteAsJsonAsync(responseModel);
            }
        }
    }

    public class ResponseModel<T>
    {
        public bool Successed { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public ResponseModel()
        {
            
        }

        public ResponseModel(T data, string message = null) 
        {
            Successed = true;
            Message = message;
            Data = data;
        }

        public ResponseModel(string message)
        {
            Successed = true;
            Message = message;
        }
    }
}
