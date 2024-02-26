namespace Apes.SugarKingdom.Application.Exceptions;

public class InvalidEntityException : Exception
{
    public InvalidEntityException(string message) : base(message) { }
    public InvalidEntityException(Type className, Guid id) : base($"Entity {className} with id {id} not found") { }
}
