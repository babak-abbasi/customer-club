namespace Domain.Write;

public interface IAuditable
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
