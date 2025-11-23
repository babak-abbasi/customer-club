namespace Domain.Write.ExceptionHandling.Types;

public class DomainLoggableException : CustomException
{
    public DomainLoggableException(string message, string loggableMessage) : base(message)
    {
        ExceptionType = ExceptionType.Loggable;
        LoggableMessage = loggableMessage;
    }

    public DomainLoggableException(string message, string loggableMessage, Exception innerException) : base(message, innerException)
    {
        ExceptionType = ExceptionType.Loggable;
        LoggableMessage = loggableMessage;
    }

    public string LoggableMessage { get; set; }
}