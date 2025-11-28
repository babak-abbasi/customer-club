using Microsoft.VisualBasic.FileIO;

namespace Domain.Write.Entities;

public class Country(int id, string code, string name, decimal order, bool isActive, bool isDeleted) 
    : AggregateRoot<int>(id, code, name, order, isActive, isDeleted)
{
    public IEnumerable<Province> Provinces { get; set; }

    public void Update(string code, string name, decimal order)
    {
        Code = code;
        Name = name;
        Order = order;
    }

    internal void Delete() => IsDeleted = true;
}