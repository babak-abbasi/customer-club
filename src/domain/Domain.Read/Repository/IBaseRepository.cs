using Helper.Pagination;

namespace Domain.Read.Repository;

public interface IBaseRepository
{
    Task<T?> GetByIdAsync<T>(string id) where T : Base;
    Task<ResponsePagination<T>> GetAsync<T, TQuery>(TQuery query) where T : Base where TQuery : RequestPagination;
}
