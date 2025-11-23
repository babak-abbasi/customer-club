using Domain.Write.Repository;

namespace Domain.Repository;

public interface ICountryRepository : IBaseRepository
{
    Task<string> AddCountryAsync(string name, string code, decimal order);
}