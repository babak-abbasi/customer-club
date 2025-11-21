using Helper.ExceptionHandling.Types;

namespace Helper.ExceptionHandling.Handler;

public class LoggableExceptionHandler : CustomExceptionHandler
{
    public override void HandleException(CustomException customException)
    {
        if (customException is LoggableException loggableException)
        {

        }
    }
}
