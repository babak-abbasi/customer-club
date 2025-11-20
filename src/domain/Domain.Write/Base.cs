namespace Domain.Write;

public abstract class Base
{
    protected Base(string code, string name, decimal order)
    {
        Code = code;
        Name = name;
        Order = order;
    }

    public string Name { get; set; }
	public string Code { get; set; }

	private DateTime _createdDate;
    public DateTime CreatedDate => _createdDate == default 
                                    ? (_createdDate = DateTime.UtcNow) 
                                    : _createdDate;

    private DateTime _updatedDate;
    public DateTime UpdatedDate => (_createdDate = DateTime.UtcNow);

    public decimal Order { get; set; }
}