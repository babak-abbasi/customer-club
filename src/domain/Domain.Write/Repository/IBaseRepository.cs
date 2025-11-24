namespace Domain.Write.Repository;

public interface IBaseRepository
{
    Task<string> AddAsync<T>(T input) where T : AggregateRoot;
    Task<T?> GetByIdAsync<T>(string id) where T : AggregateRoot;
    Task UpdateAsync<T>(string id, T entity) where T : AggregateRoot;
}
