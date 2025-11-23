using FluentResults;
using Helper.Pagination;
using MediatR;
using Service.Response.Province;

namespace Service.Queries.Province;

public class GetQuery : RequestPagination, IRequest<Result<ResponsePagination<ProvinceDto>>>
{
    public string? Name { get; set; }
    public string? Code { get; set; }
}