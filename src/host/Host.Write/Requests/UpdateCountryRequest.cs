namespace Host.Write.Requests;

public class UpdateCountryRequest
{
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Order { get; set; }
}
