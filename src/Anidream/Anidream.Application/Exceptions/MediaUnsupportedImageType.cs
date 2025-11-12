using System.Net;

namespace Anidream.Application.Exceptions;

public class MediaUnsupportedImageType : BaseException
{
    public override int StatusCode => 415;
    public MediaUnsupportedImageType(string message) 
        : base(message)
    {
    }
}