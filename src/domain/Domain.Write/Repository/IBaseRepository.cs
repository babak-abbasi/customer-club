namespace Domain.Write.Repository;

public interface IBaseRepository<TId, T> where TId : struct where T : AggregateRoot<TId>
{
    Task<TId> AddAsync(T input, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task UpdateAsync(TId id, T entity, CancellationToken cancellationToken = default);
}
