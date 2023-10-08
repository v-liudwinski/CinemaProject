namespace Cinema.Domain.ExceptionModels;

public class NotFoundException : Exception
{
    public NotFoundException(string message) 
        : base(message)
    { }
}
