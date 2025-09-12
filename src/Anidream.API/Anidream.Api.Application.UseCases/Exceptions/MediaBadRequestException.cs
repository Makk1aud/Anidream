namespace Anidream.Api.Application.Utils.Exceptions;

public class MediaBadRequestException : Exception
{
    public MediaBadRequestException(string message) 
        : base(message)
    { }
    public MediaBadRequestException(string message, Exception exception) 
        : base(message, exception)
    { }
}