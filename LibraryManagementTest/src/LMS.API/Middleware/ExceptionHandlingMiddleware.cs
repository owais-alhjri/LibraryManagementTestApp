using LMS.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                await HandleAppExceptionAsync(context, ex);
            }
            catch (Exception)
            {
                await HandleUnhandledExceptionAsync(context);
            }
        }

        private static async Task HandleAppExceptionAsync(HttpContext context, AppException exception)
        {
            var statusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status400BadRequest,
                ConflictException => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status400BadRequest
            };

            var problem = new ProblemDetails
            {
                Type = $"https://httpstatuses.com/{statusCode}",
                Title = exception.GetType().Name.Replace("Excption", ""),
                Status = statusCode,
                Detail = exception.Message,
                Instance = context.Request.Path
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsJsonAsync(problem);

        }

        private static async Task HandleUnhandledExceptionAsync(HttpContext context)
        {
            var problem = new ProblemDetails
            {
                Type = "https://httpstatuses.com/500",
                Title = "Internal Server Error",
                Status = StatusCodes.Status500InternalServerError,
                Detail = "An unexpected error occurred.",
                Instance = context.Request.Path
            };
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
