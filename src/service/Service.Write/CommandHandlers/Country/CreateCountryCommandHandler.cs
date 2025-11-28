using MediatR;
using FluentResults;
using Service.Commands.Country;
using Domain.Repository;
using Helper.ExceptionHandling.Types;
using Domain.Write.ExceptionHandling.Types;
using Domain.Write.Entities;

namespace Service.CommandHandlers.Country;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<int>>
{
    private readonly ICountryRepository repo;
    private readonly CountryService countryService;
    public CreateCountryCommandHandler(ICountryRepository repo, CountryService countryService)
    {
        this.repo = repo;
        this.countryService = countryService;
    }
    public async Task<Result<int>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var country = await countryService.CreateAsync(request.Code, request.Name, request.Order);
            var result = await repo.AddAsync(country);

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