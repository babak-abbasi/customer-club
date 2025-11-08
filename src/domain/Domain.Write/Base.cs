namespace Domain.Write;

public class Base
{
    public string Name { get; set; }
	public string Code { get; set; }
	private DateTime _createdDate;
	public DateTime CreatedDate
	{
		set => _createdDate = value;
		get
		{
			if (_createdDate == default)
				_createdDate = DateTime.UtcNow;
				
				return _createdDate;
		}
	}

	private DateTime _modifiedDate;
	public DateTime ModifiedDate
	{
		set => _modifiedDate = value;
		get => _modifiedDate = DateTime.UtcNow;
	}
}