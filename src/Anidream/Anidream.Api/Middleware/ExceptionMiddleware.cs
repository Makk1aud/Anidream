using Anidream.Application.Exceptions;

namespace Anidream.Api.Extensions.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
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
        _logger.LogError(exceptionMessage, innerMessage);
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