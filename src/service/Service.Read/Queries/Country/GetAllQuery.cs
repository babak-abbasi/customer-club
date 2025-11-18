using FluentResults;
using MediatR;
using Service.Response.Country;

namespace Service.Queries.Country;

public class GetAllQuery : IRequest<Result<List<CountryDto>>>
{
    public string Name { get; set; }
    public string Code { get; set; }
}