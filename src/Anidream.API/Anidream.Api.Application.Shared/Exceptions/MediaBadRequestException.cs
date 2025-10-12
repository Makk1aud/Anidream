using System.Net;

namespace Anidream.Api.Application.Shared.Exceptions;

public class MediaBadRequestException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    public MediaBadRequestException(string message) 
        : base(message)
    { }
    
    public MediaBadRequestException(string message, Exception exception) 
        : base(message, exception)
    { }

}