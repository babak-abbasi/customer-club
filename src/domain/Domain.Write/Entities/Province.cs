using Domain.Write.ExceptionHandling.Types;

namespace Domain.Write.Entities;

public class Province : AggregateRoot
{
    public Province(string code, string name, decimal order, string countryId) : base(code, name, order)
    {
        if (string.IsNullOrEmpty(countryId))
            throw new DomainResponsiveException(ExceptionMessage.NoParameter.NotFound);

        CountryId = countryId;
    }

    public string CountryId { get; init; }
}