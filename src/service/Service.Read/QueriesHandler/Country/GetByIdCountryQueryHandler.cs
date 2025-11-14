using MediatR;
using FluentResults;
using Service.Response.Country;
using Domain.Read.Repository;
using Service.Queries.Country;

namespace Service.QueryHandlers.Country;

public class GetByIdCountryQueryHandler: IRequestHandler<GetByIdCountryQuery, Result<CountryDto?>>
{
    private readonly ICountryReadRepository repo;
    public GetByIdCountryQueryHandler(ICountryReadRepository repo)
    {
        this.repo = repo;
    }
    public async Task<Result<CountryDto?>> Handle(GetByIdCountryQuery query, CancellationToken cancellationToken)
    {
        var result = await repo.GetCountryByIdAsync(query.Id);
        var countryDto = new CountryDto(result.Id, result.Code, result.Name, result.CreatedDate, result.ModifiedDate, result.Order);

        return Result.Ok(countryDto);
    }
}