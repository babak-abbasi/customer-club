namespace Domain.Write;

public abstract class AggregateRoot<T>
{
    protected AggregateRoot(T id,  string code, string name, decimal order)
    {
        Id = id;
        Code = code;
        Name = name;
        Order = order;
    }

    public T Id { get; set; }
    public string Name { get; set; }
	public string Code { get; set; }

	private DateTime _createdDate;
    public DateTime CreatedDate => _createdDate == default 
                                    ? (_createdDate = DateTime.UtcNow) 
                                    : _createdDate;

    private DateTime _updatedDate;
    public DateTime UpdatedDate => (_createdDate = DateTime.UtcNow);

    public decimal Order { get; set; }

    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;

    public void Delete() => IsDeleted = true;
    public void Activate() => IsActive = true;
    public void DeActivate() => IsActive = false;
}