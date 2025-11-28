using Domain.Repository;
using Domain.Write.Entities;
using Domain.Write.ExceptionHandling.Types;
using FluentResults;
using Helper.ExceptionHandling.Types;
using MediatR;
using Service.Write;
using Service.Write.Commands.Country;

namespace Service.CommandHandlers.Country;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Result>
{
    private readonly ICountryRepository repo;
    private readonly CountryService countryService;
    public DeleteCountryCommandHandler(ICountryRepository repo, CountryService countryService)
    {
        this.repo = repo;
        this.countryService = countryService;
    }
    public async Task<Result> Handle(DeleteCountryCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            await countryService.DeleteAsync(request.Id);

            //await repo.UpdateAsync(request.Id, country);

            return Result.Ok();
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