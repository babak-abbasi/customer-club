using Domain.Read;

namespace Domain.Entities.Read;

public class Province : AggreagateRoot
{
    public string CountryId { get; set; }
    public Country Country { get; set; }
}