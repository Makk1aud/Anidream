using System.Net;

namespace Anidream.Application.Exceptions;

public class MediaUnsupportedImageType : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.UnsupportedMediaType;
    public MediaUnsupportedImageType(string message) 
        : base(message)
    {
    }
}