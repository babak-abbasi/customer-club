using FluentResults;
using MediatR;
using Service.Response.Country;

namespace Service.Queries.Country;

public class GetByIdQuery: IRequest<Result<CountryDto?>>
{
    public string Id { get; set; }
}