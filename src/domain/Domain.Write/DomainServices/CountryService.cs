using Domain.Repository;
using Domain.Write.Entities;
using Helper.ExceptionHandling.Types;

namespace Domain.Write.DomainServices;

public class CountryService(ICountryRepository countryRepository)
{
    public async Task<Country> CreateAsync(string code, string name, decimal order)
    {
        var sameCodeExist = await countryRepository.SameCodeExistAsync(code);
        var sameNameExist = await countryRepository.SameNameExistAsync(name);

        if (sameCodeExist)
            throw new ResponsiveException(ExceptionMessage.NoParameter.SameCodeExist);
        if (sameNameExist)
            throw new ResponsiveException(ExceptionMessage.NoParameter.SameNameExist);

        return new Country(default, code, name, order, true, false);
    }

    public async Task UpdateAsync(Country country, string code, string name, decimal order)
    {
        var sameCodeExist = await countryRepository.SameCodeExistAsync(country.Id, code);
        var sameNameExist = await countryRepository.SameNameExistAsync(country.Id, name);

        if (sameCodeExist)
            throw new ResponsiveException(ExceptionMessage.NoParameter.SameCodeExist);
        if (sameNameExist)
            throw new ResponsiveException(ExceptionMessage.NoParameter.SameNameExist);

        country.Update(code, name, order);
    }

    public async Task DeleteAsync(int id)
    {
        var country = await countryRepository.GetByIdAsync(id);

        if (country is null)
            throw new ResponsiveException(ExceptionMessage.WithParameter.NotFound(nameof(Country)), new ArgumentNullException(nameof(country)));

        country.Delete();
    }
}
