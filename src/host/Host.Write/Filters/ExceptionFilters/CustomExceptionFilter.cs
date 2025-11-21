using FluentResults;
using Helper.ExceptionHandling.Handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Host.Write.Filters.ExceptionFilters;

public class CustomExceptionFilter : IExceptionFilter
{
    private readonly CustomExceptionRegistery registery;

    public CustomExceptionFilter(CustomExceptionRegistery registery)
    {
        this.registery = registery;
    }

    public void OnException(ExceptionContext context)
    {
        if(context.Exception is Helper.ExceptionHandling.Types.CustomException customException) 
        {
            registery.Handle(customException);

            context.ExceptionHandled = true;

            context.Result = new ObjectResult(Result.Fail(customException.Message));
        }
    }
}