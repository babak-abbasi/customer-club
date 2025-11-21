using FluentResults;
using Helper.Pagination;
using MediatR;
using Service.Response.Country;

namespace Service.Queries.Country;

public class GetAllQuery : RequestPagination, IRequest<Result<List<CountryDto>>>
{
    public string Name { get; set; }
    public string Code { get; set; }
}