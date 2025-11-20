using Domain.Read.Repository;
using FluentResults;
using MediatR;
using Service.Queries.Country;
using Service.Response.Country;

namespace Service.QueryHandlers.Country;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, Result<List<CountryDto>>>
{
    private readonly ICountryReadRepository repo;

    public GetAllQueryHandler(ICountryReadRepository repo)
    {
        this.repo = repo;
    }

    public async Task<Result<List<CountryDto>>> Handle(GetAllQuery query, CancellationToken cancellationToken)
    {
        var result = await repo.GetAllAsync<Domain.Entities.Read.Country>();
        var countryDto =
                    result
                    .Select(country => new CountryDto(country.Id, country.Code, country.Name, country.CreatedDate, country.UpdatedDate, country.Order))
                    .ToList();

        return Result.Ok(countryDto);
    }
}