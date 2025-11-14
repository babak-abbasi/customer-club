using Domain.Entities.Read;

namespace Domain.Read.Repository;

public interface ICountryReadRepository
{
    Task<Country?> GetCountryByIdAsync(string id);
}