namespace Anidream.Api.Application.Shared.Exceptions;

public class StorageException : BaseException
{
    public StorageException(string message, Exception exception)
        : base(message, 500, exception)
    { }
}