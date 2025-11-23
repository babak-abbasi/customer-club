using FluentResults;
using Helper.ExceptionHandling.Handler;

namespace Host.Read.CustomMiddlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly CustomExceptionRegistery _registry;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, CustomExceptionRegistery registry)
    {
        _next = next;
        _logger = logger;
        _registry = registry;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ExceptionMessage.NoParameter.Unhandled_Exception);
            await ReadFluentError(context, StatusCodes.Status500InternalServerError, ExceptionMessage.NoParameter.An_Unexpected_Error_Occurred);
        }
    }

    private static async Task ReadFluentError(HttpContext context, int statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var result = Result.Fail(message);
        var json = System.Text.Json.JsonSerializer.Serialize(result);

        await context.Response.WriteAsync(json);
    }
}
