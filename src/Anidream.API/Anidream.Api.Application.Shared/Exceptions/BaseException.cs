namespace Anidream.Api.Application.Shared.Exceptions;

public abstract class BaseException : Exception
{
    public int StatusCode { get; }
    public string? InnerMessage { get; }

    public BaseException(string message, int statusCode)
        : base(message)
    {
        StatusCode = statusCode;
        InnerMessage = base.InnerException?.Message;
    }
    
    public BaseException(string message, int statusCode, Exception exception)
        : base(message, exception)
    {
        StatusCode = statusCode;
        InnerMessage = base.InnerException?.Message;
    }
}