namespace Service.Response.Country;

public record CountryDto(string Id, string Code, string Name, DateTime CreatedDate, DateTime ModifiedDate, long Order);