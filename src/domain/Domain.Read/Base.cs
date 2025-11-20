namespace Domain.Read;

public class Base
{
	public string Id { get; set; }
    public string Name { get; set; }
	public string Code { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime UpdatedDate { get; set; }

	public long Order { get; set; }
}