namespace Anidream.Api.Application.Shared.Exceptions;

public class MediaNotFoundException : BaseException
{
    public MediaNotFoundException(string id) 
        : base($"Media с id: {id} не найдено или удалено", 404)
    { }
}