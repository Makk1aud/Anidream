using System.Net;

namespace Anidream.Application.Exceptions;

public class MediaNotFoundException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;
    public MediaNotFoundException(Guid id) 
        : base($"Media с id: {id} не найдено или удалено")
    { }
    
    public MediaNotFoundException(string alias) 
        : base($"Media с alias: {alias} не найдено или удалено")
    { }
}