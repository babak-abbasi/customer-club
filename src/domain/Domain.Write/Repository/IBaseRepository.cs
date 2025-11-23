namespace Domain.Write.Repository;

public interface IBaseRepository
{
    Task<T?> GetByIdAsync<T>(string id) where T : Base;
}
