namespace Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key)
        : base($"'{name}' avec l'id ({key}) est introuvable.") { }
}