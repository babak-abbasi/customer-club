using Helper.ExceptionHandling.Types;

namespace Helper.ExceptionHandling.Handler;

public interface CustomExceptionHandler
{
    public void HandleException(CustomException customException);
}