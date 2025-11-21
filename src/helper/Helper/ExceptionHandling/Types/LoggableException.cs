namespace Helper.ExceptionHandling.Types;

public class LoggableException : CustomException
{
    public LoggableException(string message, string loggableMessage) : base(message)
    {
        ExceptionType = ExceptionType.Loggable;
        LoggableMessage = loggableMessage;
    }

    public LoggableException(string message, string loggableMessage, Exception innerException) : base(message, innerException)
    {
        ExceptionType = ExceptionType.Loggable;
        LoggableMessage = loggableMessage;
    }

    public string LoggableMessage { get; set; }
}