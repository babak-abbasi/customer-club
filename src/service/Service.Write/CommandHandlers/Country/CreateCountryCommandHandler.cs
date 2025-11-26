using MediatR;
using FluentResults;
using Service.Commands.Country;
using Domain.Repository;
using Helper.ExceptionHandling.Types;
using Domain.Write.ExceptionHandling.Types;

namespace Service.CommandHandlers.Country;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<int>>
{
    private readonly ICountryRepository repo;
    public CreateCountryCommandHandler(ICountryRepository repo)
    {
        this.repo = repo;
    }
    public async Task<Result<int>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await repo.AddAsync(new Domain.Write.Entities.Country(default, request.Name, request.Code, request.Order));

            return Result.Ok(result);
        }
        catch (DomainResponsiveException exception)
        {
            throw new ResponsiveException(exception.Message);
        }
        catch (DomainLoggableException exception)
        {
            throw new LoggableException(exception.Message, exception.LoggableMessage);
        }
        catch (Exception)
        {
            throw;
        }
    }
}