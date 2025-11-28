using Domain.Repository;
using Domain.Write.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Write.EFContext;

namespace Repository.Write;

public class CountryRepository(EFDBContext eFContext) : BaseRepository<int, Country>(eFContext), ICountryRepository
{
    public async Task<bool> SameCodeExistAsync(string code, CancellationToken cancellationToken = default)
    {
        return await eFContext.Countries.AnyAsync(a => a.Code == code && !a.IsDeleted);
    }

    public async Task<bool> SameNameExistAsync(string name, CancellationToken cancellationToken = default)
    {
        return await eFContext.Countries.AnyAsync(a => a.Name == name && !a.IsDeleted);
    }

    public async Task<bool> SameCodeExistAsync(int id, string code, CancellationToken cancellationToken = default) 
    {
        return await eFContext.Countries.AnyAsync(a => a.Code == code && a.Id != id && !a.IsDeleted);
    }

    public async Task<bool> SameNameExistAsync(int id, string name, CancellationToken cancellationToken = default)
    {
        return await eFContext.Countries.AnyAsync(a => a.Name == name && a.Id != id && !a.IsDeleted);
    }
}
