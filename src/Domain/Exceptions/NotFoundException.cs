namespace Domain.Exceptions;

public class NotFoundException : InvalidOperationException
{
    public NotFoundException(string entityName, int id)
        : base($"Entity of type {entityName} with id {id} was not found.")
    {
    }
}
