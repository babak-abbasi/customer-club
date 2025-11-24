namespace Domain.Write.Entities;

public class Country(string code, string name, decimal order) : AggregateRoot(code, name, order)
{
    public void Update(string code, string name, decimal order)
    {
        Code = code;
        Name = name;
        Order = order;
    }
}