using Project_management_system.Enums;
using Project_management_system.Exceptions;
using Project_management_system.ViewModels;

namespace Project_management_system.Middelwares
{
    public class GlobalErrorHandlerMiddleware
    {
        public RequestDelegate _next;
        public GlobalErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string message = "Error Occured";
                ErrorCode errorCode = ErrorCode.NoError;

                if (ex is BusinessException businessException)
                {
                    message = businessException.Message;
                    errorCode = businessException.ErrorCode;
                }


                var result = ResultVM<bool>.Faliure(errorCode, message);

                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }
}

