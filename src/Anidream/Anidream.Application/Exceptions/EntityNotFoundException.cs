namespace Anidream.Application.Exceptions;

public class EntityNotFoundException : BaseException
{
    public override int StatusCode => 404;
    
    public EntityNotFoundException(string entityName) : base($"{entityName} не найдено")
    {
    }
    
    public EntityNotFoundException(string entityName, Guid id) : base($"{entityName} с id: {id}, не найдено")
    {
    }

    public EntityNotFoundException(string entityName, string alias) : base($"{entityName} с alias: {alias}, не найдено")
    {
    }

    public EntityNotFoundException(string message, Exception exception) : base(message, exception)
    {
    }
}