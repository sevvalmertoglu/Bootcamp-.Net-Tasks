using LibraryManagementAPI.Models;
using LibraryManagementAPI.Exceptions;
using System.Net;

namespace LibraryManagementAPI.Middleware.ErrorHandlingMiddleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomException ex)
            {
                _logger.LogError($"Custom Exception: {ex.Message}");

                var statusCode = ex switch
                {
                    NotFoundException => HttpStatusCode.NotFound,
                    ValidationException => HttpStatusCode.BadRequest,
                    _ => HttpStatusCode.InternalServerError
                };

                var errorResponse = new ErrorModel
                {
                    Message = ex.Message,
                    Code = ex.ErrorCode,
                    Detail = ex.StackTrace ?? "No stack trace available."
                };

                httpContext.Response.StatusCode = (int)statusCode;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unhandled Exception: {ex.Message}");
                
                var errorResponse = new ErrorModel
                {
                    Message = "An unexpected error occurred.",
                    Code = "INTERNAL_SERVER_ERROR",
                    Detail = ex.StackTrace ?? "No stack trace available."
                };

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
