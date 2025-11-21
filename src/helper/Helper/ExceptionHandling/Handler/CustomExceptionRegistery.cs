using Helper.ExceptionHandling.Types;

namespace Helper.ExceptionHandling.Handler;

public class CustomExceptionRegistery
{
    Dictionary<Type, CustomExceptionHandler> registery = new();

    public void Register<T>(CustomExceptionHandler handler) where T : CustomException
    {
        registery.Add(typeof(T), handler);
    }

    public void Handle(CustomException customException)
    {
        var handlerGetter = registery.TryGetValue(customException.GetType(), out var handler);
        if (handlerGetter)
        {
            handler.HandleException(customException);
        }
    }
}
