using Domain.Repository;
using Domain.Write.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Write.EFContext;


namespace Repository.Write;

public class ProvinceRepository(EFDBContext eFContext) : BaseRepository<int, Province>(eFContext), IProvinceRepository
{
    public async Task<Province?> GetByCountryIdAsync(int countryId, CancellationToken cancellationToken)
        => await eFContext.Provinces.FirstOrDefaultAsync(f => f.CountryId == countryId, cancellationToken);
}
