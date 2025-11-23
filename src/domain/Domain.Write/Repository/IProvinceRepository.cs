namespace Domain.Repository;

public interface IProvinceRepository
{
    Task<string> AddProvinceAsync(string name, string code, decimal order, string countryId);
}