using Domain.Read;

namespace Domain.Entities.Read;

public class Country : AggreagateRoot
{
    public ICollection<Province>? Province { get; set; }
}