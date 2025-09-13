namespace Anidream.Api.Application.Shared.Exceptions;

public class MediaBadRequestException : BaseException
{
    public MediaBadRequestException(string message) 
        : base(message, 400)
    { }
    
    public MediaBadRequestException(string message, Exception exception) 
        : base(message, 400, exception)
    { }
}