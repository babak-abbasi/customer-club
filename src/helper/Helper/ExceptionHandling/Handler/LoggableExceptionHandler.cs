using Helper.ExceptionHandling.Types;

namespace Helper.ExceptionHandling.Handler;

public class LoggableExceptionHandler : CustomExceptionHandler
{
    public void HandleException(CustomException customException)
    {
        if (customException is LoggableException loggableException)
        {

        }
    }
}
