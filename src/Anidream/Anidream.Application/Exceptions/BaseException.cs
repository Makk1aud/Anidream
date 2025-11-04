namespace Anidream.Application.Exceptions;

public abstract class BaseException : Exception
{
    public abstract int StatusCode { get; }
    public string? InnerMessage { get; }

    public BaseException(string message)
        : base(message)
    {
        InnerMessage = base.InnerException?.Message;
    }
    
    public BaseException(string message, Exception exception)
        : base(message, exception)
    {
        InnerMessage = base.InnerException?.Message;
    }
}