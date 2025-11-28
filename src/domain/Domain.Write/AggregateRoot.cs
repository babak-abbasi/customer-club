
namespace Domain.Write;

public abstract class AggregateRoot<T> : IAuditable where T : struct
{
    protected AggregateRoot(T id, string code, string name, decimal order, bool isActive, bool isDeleted)
    {
        Id = id;
        Code = code;
        Name = name;
        Order = order;
        IsActive = isActive;
        IsDeleted = isDeleted;
    }

    public T Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public decimal Order { get; set; }

    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public void Delete() => IsDeleted = true;
    public void Activate() => IsActive = true;
    public void DeActivate() => IsActive = false;
}