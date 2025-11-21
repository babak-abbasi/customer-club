using Helper.CustomException;
using Microsoft.AspNetCore.Diagnostics;

namespace CustomMiddlewares;

public class CustomExceptionHandler
{
    private readonly ILogger<CustomExceptionHandler> logger;

    public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
    {
        this.logger = logger;
    }

    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if(exception is CustomException customException)
        {
            
        }

        logger.LogError(@$"Error Message: {exception.Message}, Time of occurrence {DateTime.UtcNow}");

        return ValueTask.FromResult(false);
    }
}