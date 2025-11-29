using Service.Read.Repository;
using FluentResults;
using Helper.Pagination;
using MediatR;
using Service.Queries.Province;
using Service.Response.Province;

namespace Service.QueryHandlers.Province;

public class GetQueryHandler : IRequestHandler<GetQuery, Result<ResponsePagination<ProvinceDto>>>
{
    private readonly IProvinceReadRepository repo;

    public GetQueryHandler(IProvinceReadRepository repo)
    {
        this.repo = repo;
    }

    public async Task<Result<ResponsePagination<ProvinceDto>?>> Handle(GetQuery query, CancellationToken cancellationToken = default)
    {
        ResponsePagination<ProvinceDto>? ProvinceDto = new()
        {
            PageNumber = query.PageNumber,
            PageSize = query.PageSize,
        };
        var result = await repo.GetAsync<Domain.Entities.Read.Province, GetQuery>(query);
        if (result.Data is not null && result.Data.Count > 0)
        {
            ProvinceDto.Data = result
                    .Data
                    .Select(Province => new ProvinceDto(Province.Id, Province.Code, Province.Name, Province.CreatedDate, Province.UpdatedDate, Province.Order))
                    .ToList();
            ProvinceDto.CurrentSize = result.CurrentSize;
            ProvinceDto.HasPreviuos = result.HasPreviuos;
            ProvinceDto.HasNext = result.HasNext;
            ProvinceDto.TotalCount = result.TotalCount;
        }

        return Result.Ok(ProvinceDto);
    }
}