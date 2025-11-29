using MediatR;
using FluentResults;
using Service.Response.Country;
using Service.Read.Repository;
using Service.Queries.Country;
using Helper.ExceptionHandling.Types;
using Domain.Read.ExceptionHandling.Types;

namespace Service.QueryHandlers.Country;

public class GetByIdQueryHandler: IRequestHandler<GetByIdQuery, Result<CountryDto?>>
{
    private readonly ICountryReadRepository repo;
    public GetByIdQueryHandler(ICountryReadRepository repo)
    {
        this.repo = repo;
    }
    public async Task<Result<CountryDto?>> Handle(GetByIdQuery query, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await repo.GetByIdAsync<Domain.Entities.Read.Country>(query.Id);
            var countryDto = new CountryDto(query.Id, result!.Code, result!.Name, result!.CreatedDate, result!.UpdatedDate, result!.Order);

            return Result.Ok(countryDto!);
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