using System.Net;

namespace Anidream.Application.Exceptions;

public class MediaBadRequestException : BaseException
{
    public override int StatusCode => 400;
    public MediaBadRequestException(string message) 
        : base(message)
    { }
    
    public MediaBadRequestException(string message, Exception exception) 
        : base(message, exception)
    { }

}