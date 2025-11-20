using Domain.Write.Entities;

namespace Domain.Write.Test;

public class Base
{
    //Base is abstract so we test it with other entities

    Country country { get; set; }
    public string code = string.Empty;
    public string name = string.Empty;
    public decimal order = 0.0M;
    public Base()
    {
        country = new(code, name, order);
    }

    [Fact]
    public void CreatedDate_ShouldInitialize_WhenDefault()
    {
        // Arrange
        var country = new Country(code, name, order);

        // Act
        var firstRead = country.CreatedDate;
        var secondRead = country.CreatedDate;

        // Assert
        Assert.NotEqual(default, firstRead);    // Should be initialized
        Assert.Equal(firstRead, secondRead);    // Should not change on subsequent reads
    }

    [Fact]
    public void UpdatedDate_ShouldChange_GetAgain()
    {
        // Arrange
        var country = new Country(code, name, order);

        // Act
        var firstRead = country.UpdatedDate;
        var secondRead = country.UpdatedDate;

        // Assert
        Assert.NotEqual(firstRead, secondRead); // Should change on subsequent reads
    }
}