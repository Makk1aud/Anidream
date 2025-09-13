namespace Anidream.Api.Application.Shared.Exceptions;

public class MediaUnsupportedImageType : BaseException
{
    public MediaUnsupportedImageType(string message) 
        : base(message, 400)
    {
    }
}