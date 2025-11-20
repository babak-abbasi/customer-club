namespace Domain.Repository;

public interface ICountryRepository
{
    Task<string> AddCountryAsync(string name, string code, decimal order);
}