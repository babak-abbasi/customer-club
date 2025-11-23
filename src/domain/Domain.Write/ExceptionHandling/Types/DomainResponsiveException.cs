namespace Domain.Write.ExceptionHandling.Types;

public class DomainResponsiveException : CustomException
{
    public DomainResponsiveException(string message) : base(message)
    {
    }

    public DomainResponsiveException(string message, Exception innerException) : base(message, innerException)
    {
    }
}