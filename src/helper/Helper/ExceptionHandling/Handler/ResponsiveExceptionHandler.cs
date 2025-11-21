using Helper.ExceptionHandling.Types;

namespace Helper.ExceptionHandling.Handler;

public class ResponsiveExceptionHandler : CustomExceptionHandler
{
    public override void HandleException(CustomException customException)
    {
        if (customException is ResponsiveException responsiveException)
        {
            
        }
    }
}
