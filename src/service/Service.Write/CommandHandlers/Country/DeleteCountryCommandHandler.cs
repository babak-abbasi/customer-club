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
    private readonly IProvinceRepository provinceRepo;

    public DeleteCountryCommandHandler(ICountryRepository repo, IProvinceRepository provinceRepo, CountryService countryService)
    {
        this.repo = repo;
        this.countryService = countryService;
        this.provinceRepo = provinceRepo;
    }
    public async Task<Result> Handle(DeleteCountryCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var country = await repo.GetByIdAsync(request.Id);
            if (country is null)
                throw new ResponsiveException(ExceptionMessage.WithParameter.NotFound(nameof(Domain.Write.Entities.Country)), new ArgumentNullException(nameof(country)));

            var province = provinceRepo.GetByCountryIdAsync(country.Id, cancellationToken);
            if (province != null)
                throw new ResponsiveException(ExceptionMessage.NoParameter.Data_Has_Been_Used);

            await countryService.DeleteAsync(request.Id);
            await repo.UpdateAsync(request.Id, country);

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