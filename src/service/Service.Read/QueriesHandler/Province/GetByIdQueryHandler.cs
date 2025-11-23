using MediatR;
using FluentResults;
using Service.Response.Province;
using Service.Read.Repository;
using Service.Queries.Province;

namespace Service.QueryHandlers.Province;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Result<ProvinceDto?>>
{
    private readonly IProvinceReadRepository repo;
    public GetByIdQueryHandler(IProvinceReadRepository repo)
    {
        this.repo = repo;
    }
    public async Task<Result<ProvinceDto?>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await repo.GetByIdAsync<Domain.Entities.Read.Province>(query.Id);
        var ProvinceDto = new ProvinceDto(query.Id, result.Code, result.Name, result.CreatedDate, result.UpdatedDate, result.Order);

        return Result.Ok(ProvinceDto);
    }
}