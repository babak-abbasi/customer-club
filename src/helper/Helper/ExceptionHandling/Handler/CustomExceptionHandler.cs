using Helper.ExceptionHandling.Types;

namespace Helper.ExceptionHandling.Handler;

public abstract class CustomExceptionHandler
{
    public abstract void HandleException(CustomException customException);
}