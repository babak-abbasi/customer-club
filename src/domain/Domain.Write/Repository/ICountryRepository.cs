using Domain.Write.Entities;
using Domain.Write.Repository;

namespace Domain.Repository;

public interface ICountryRepository : IBaseRepository<int, Country>
{
}