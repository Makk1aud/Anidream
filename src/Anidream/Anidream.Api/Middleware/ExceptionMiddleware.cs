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
        BaseException baseException => HandleExceptionAsync(context, CreateProblemDetailsByException(baseException, baseException.StatusCode)),
        ValidationException validationException => HandleExceptionAsync(context, CreateProblemDetailsByValidationException(validationException)),
        _ => HandleExceptionAsync(context, CreateProblemDetailsByException(exception, StatusCodes.Status500InternalServerError))
    };
                
    private async Task HandleExceptionAsync(HttpContext context, ProblemDetails problemDetails)
    {
        context.Response.StatusCode = problemDetails.Status!.Value;
        
        _logger.LogError("{ProblemDetailsTitle}", problemDetails.Title);
        await context.Response.WriteAsJsonAsync(problemDetails).ConfigureAwait(false);
        
        context.Response.ContentType = "application/json";
    }
    
    private ProblemDetails CreateProblemDetailsByException(Exception exception, int statusCode) => new ProblemDetails()
    {
        Title = exception.Message,
        Status = statusCode
    };

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