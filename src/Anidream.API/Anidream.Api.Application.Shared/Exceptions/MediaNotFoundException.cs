namespace Anidream.Api.Application.Shared.Exceptions;

public class MediaNotFoundException : BaseException
{
    public MediaNotFoundException(Guid id) 
        : base($"Media с id: {id} не найдено или удалено", 404)
    { }
    
    public MediaNotFoundException(string alias) 
        : base($"Media с alias: {alias} не найдено или удалено", 404)
    { }
}