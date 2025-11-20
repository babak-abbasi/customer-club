namespace Helper.CustomException;

public class LoggableException : CustomException
{
    public LoggableException(string message, string loggableMessage)
    {
        ExceptionType = ExceptionType.Loggable;
        LoggableMessage = loggableMessage;
    }

    public string LoggableMessage { get; set; }
}