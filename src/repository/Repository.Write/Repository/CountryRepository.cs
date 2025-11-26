using Domain.Repository;
using Domain.Write.Entities;
using Repository.Write.EFContext;

namespace Repository.Write;

public class CountryRepository(EFDBContext eFContext) : BaseRepository<int, Country>(eFContext), ICountryRepository
{

}
