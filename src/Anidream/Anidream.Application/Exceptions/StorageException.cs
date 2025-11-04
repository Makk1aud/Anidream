using System.Net;

namespace Anidream.Application.Exceptions;

public class StorageException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.InternalServerError;
    public StorageException(string message)
        : base(message)
    { }
    public StorageException(string message, Exception exception)
        : base(message, exception)
    { }
}