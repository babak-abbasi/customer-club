namespace Domain.Read.Repository;

public interface IBaseRepository
{
    Task<T?> GetByIdAsync<T>(string id) where T : Base;
    Task<List<T>> GetAllAsync<T>() where T : Base;
}
