using Domain.Read;
using Helper.Pagination;

namespace Service.Read.Repository;

public interface IBaseRepository
{
    Task<T> GetByIdAsync<T>(string id, CancellationToken cancellationToken = default) where T : AggreagateRoot;
    Task<ResponsePagination<T>> GetAsync<T, TQuery>(TQuery query, CancellationToken cancellationToken = default) where T : AggreagateRoot where TQuery : RequestPagination;
}
