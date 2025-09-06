namespace Anidream.Api.Application.Utils.Exceptions;

public class MediaNotFoundException : Exception
{
    public MediaNotFoundException(string message) 
        : base(message)
    { }
}