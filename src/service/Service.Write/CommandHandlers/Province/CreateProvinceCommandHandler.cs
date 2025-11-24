using Domain.Repository;
using Domain.Write.ExceptionHandling.Types;
using FluentResults;
using Helper.ExceptionHandling.Types;
using MediatR;
using Service.Commands.Province;
using Service.Write;

namespace Service.CommandHandlers.Province;

public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand, Result<string>>
{
    private readonly IProvinceRepository repo;
    private readonly ICountryRepository countryRepo;
    public CreateProvinceCommandHandler(IProvinceRepository repo, ICountryRepository countryRepo)
    {
        this.repo = repo;
        this.countryRepo = countryRepo;
    }
    public async Task<Result<string>> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var country = await countryRepo.GetByIdAsync<Domain.Write.Entities.Country>(request.CountryId);
            if (country is null)
                throw new ResponsiveException(ExceptionMessage.WithParameter.NotFound(nameof(Domain.Write.Entities.Country)), new ArgumentNullException(nameof(country)));

            var result = await repo.AddAsync<Domain.Write.Entities.Province>(new Domain.Write.Entities.Province(request.Name, request.Code, request.Order, request.CountryId));

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