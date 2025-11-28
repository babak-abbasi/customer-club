using Domain.Write.Entities;
using Domain.Write.Repository;

namespace Domain.Repository;

public interface ICountryRepository : IBaseRepository<int, Country>
{
    Task<bool> SameCodeExistAsync(string code, CancellationToken cancellationToken = default);
    Task<bool> SameNameExistAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> SameCodeExistAsync(int id, string code, CancellationToken cancellationToken = default);
    Task<bool> SameNameExistAsync(int id, string name, CancellationToken cancellationToken = default);
}