namespace Domain.Write.Entities;

public class Country(int id, string code, string name, decimal order) : AggregateRoot<int>(id, code, name, order)
{
    public void Update(string code, string name, decimal order)
    {
        Code = code;
        Name = name;
        Order = order;
    }

    public IEnumerable<Province> Provinces { get; set; }
}