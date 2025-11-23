using Helper.ExceptionHandling.Types;

namespace Helper.ExceptionHandling.Handler;

public class ResponsiveExceptionHandler : CustomExceptionHandler
{
    public void HandleException(CustomException customException)
    {
        if (customException is ResponsiveException responsiveException)
        {
            
        }
    }
}
