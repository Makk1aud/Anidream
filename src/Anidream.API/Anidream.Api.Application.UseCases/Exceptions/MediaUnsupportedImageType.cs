namespace Anidream.Api.Application.Utils.Exceptions;

public class MediaUnsupportedImageType : BaseException
{
    public MediaUnsupportedImageType(string message) 
        : base(message, 400)
    {
    }
}