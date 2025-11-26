namespace Domain.Write.Entities;

public class Province : AggregateRoot<int>
{
    public Province(int id, string code, string name, decimal order, int countryId) : base(id, code, name, order)
    {
        CountryId = countryId;
    }

    public int CountryId { get; init; }
    public Country Country { get; init; }
}