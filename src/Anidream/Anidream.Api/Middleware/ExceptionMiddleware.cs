using Anidream.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Anidream.Api.Middleware;

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

    private Task HandleExceptionAsync(HttpContext context, Exception exception) => exception switch
    {
        BaseException baseException => HandleExceptionAsync(context, CreateProblemDetailsByException(baseException, baseException.StatusCode, exception)),
        ValidationException validationException => HandleExceptionAsync(context, CreateProblemDetailsByValidationException(validationException)),
        _ => HandleExceptionAsync(context, CreateProblemDetailsByException(exception, StatusCodes.Status500InternalServerError, exception))
    };
                
    private async Task HandleExceptionAsync(HttpContext context, ProblemDetails problemDetails)
    {
        if (context.Response.HasStarted)
        {
            _logger.LogError("Cannot write error response, headers already sent. Problem: {ProblemDetailsTitle}", problemDetails.Title);
            return;
        }

        context.Response.StatusCode = problemDetails.Status!.Value;
        context.Response.ContentType = "application/json";
        
        _logger.LogError("{ProblemDetailsTitle}", problemDetails.Title);
        await context.Response.WriteAsJsonAsync(problemDetails).ConfigureAwait(false);
    }
    
    private ProblemDetails CreateProblemDetailsByException(Exception exception, int statusCode, Exception? original = null)
    {
        var details = new ProblemDetails()
    {
        Title = exception.Message,
        Status = statusCode
    };

        var inner = original?.InnerException;
        if (inner != null)
        {
            details.Extensions["innerException"] = inner.Message;
            var deepest = GetInnermostException(inner);
            if (deepest != null && deepest != inner)
                details.Extensions["innerMostException"] = deepest.Message;
        }

        return details;
    }
    
    private static Exception? GetInnermostException(Exception exception)
    {
        var current = exception;
        while (current.InnerException != null)
            current = current.InnerException;
        return current;
    }

    private ProblemDetails CreateProblemDetailsByValidationException(ValidationException exception)
    {
        var problemDetails = new ProblemDetails();
        problemDetails.Title = "One or more validation errors occurred.";
        problemDetails.Type = "Validation errors";
        problemDetails.Extensions.Add("errors", exception.Errors.Select(e => $"{e.ErrorMessage}"));
        problemDetails.Status = StatusCodes.Status400BadRequest;
        return problemDetails;
    }
}