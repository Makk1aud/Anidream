using Anidream.Api.Application.Utils.Exceptions;

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

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception switch
        {
            MediaBadRequestException => StatusCodes.Status400BadRequest,
            MediaNotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
        
        var message = exception.Message;
        await context.Response.WriteAsync(new ErrorDetails
        {
            Message = message,
            StatusCode = context.Response.StatusCode,
            InnerMessage = exception.InnerException?.Message
        }.ToString());
    }
}