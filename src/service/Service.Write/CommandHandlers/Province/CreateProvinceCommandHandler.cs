using Domain.Repository;
using Domain.Write.ExceptionHandling.Types;
using FluentResults;
using Helper.ExceptionHandling.Types;
using MediatR;
using Service.Commands.Province;
using Service.Write;

namespace Service.CommandHandlers.Province;

public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand, Result<int>>
{
    private readonly IProvinceRepository repo;
    private readonly ICountryRepository countryRepo;
    public CreateProvinceCommandHandler(IProvinceRepository repo, ICountryRepository countryRepo)
    {
        this.repo = repo;
        this.countryRepo = countryRepo;
    }
    public async Task<Result<int>> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var country = await countryRepo.GetByIdAsync(request.CountryId);
            if (country is null)
                throw new ResponsiveException(ExceptionMessage.WithParameter.NotFound(nameof(Domain.Write.Entities.Country)), new ArgumentNullException(nameof(country)));

            var result = await repo.AddAsync(new Domain.Write.Entities.Province(default, request.Name, request.Code, request.Order, request.CountryId));

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