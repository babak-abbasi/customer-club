using Service.Read.Repository;
using FluentResults;
using Helper.Pagination;
using MediatR;
using Service.Queries.Country;
using Service.Response.Country;

namespace Service.QueryHandlers.Country;

public class GetQueryHandler : IRequestHandler<GetQuery, Result<ResponsePagination<CountryDto>>>
{
    private readonly ICountryReadRepository repo;

    public GetQueryHandler(ICountryReadRepository repo)
    {
        this.repo = repo;
    }

    public async Task<Result<ResponsePagination<CountryDto>?>> Handle(GetQuery query, CancellationToken cancellationToken)
    {
        ResponsePagination<CountryDto>? countryDto = new() 
        { 
            PageNumber = query.PageNumber,
            PageSize = query.PageSize,
        };
        var result = await repo.GetAsync<Domain.Entities.Read.Country, GetQuery>(query);
        if(result.Data is not null && result.Data.Count > 0)
        {
            countryDto.Data = result
                    .Data
                    .Select(country => new CountryDto(country.Id, country.Code, country.Name, country.CreatedDate, country.UpdatedDate, country.Order))
                    .ToList();
            countryDto.CurrentSize = result.CurrentSize;
            countryDto.HasPreviuos = result.HasPreviuos;
            countryDto.HasNext = result.HasNext;
            countryDto.TotalCount = result.TotalCount;
        }

        return Result.Ok(countryDto);
    }
}