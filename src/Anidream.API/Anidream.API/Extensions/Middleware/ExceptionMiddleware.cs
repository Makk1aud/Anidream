using Anidream.Api.Application.Shared.Exceptions;

namespace Anidream.API.Extensions.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception) =>
        exception is BaseException baseException 
            ? HandleExceptionAsync(context, baseException.Message, baseException.StatusCode, baseException.InnerMessage) 
            : HandleExceptionAsync(context, exception.Message, StatusCodes.Status500InternalServerError, exception.InnerException?.Message);

    private async Task HandleExceptionAsync(HttpContext context, string exceptionMessage, int statusCode, string? innerMessage)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(new ErrorDetails
        {
            Message = exceptionMessage,
            StatusCode = context.Response.StatusCode,
            InnerMessage = innerMessage
        }.ToString());
    }
}