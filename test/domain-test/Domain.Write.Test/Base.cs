using Domain.Write.Entities;

namespace Domain.Write.Test;

public class Base
{
    //Base is abstract so we test it with other entities

    Country country { get; set; }
    public Base()
    {
        country = new();
    }

    [Fact]
    public void CreatedDate_ShouldInitialize_WhenDefault()
    {
        // Arrange
        var country = new Country();

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
        var country = new Country();

        // Act
        var firstRead = country.UpdatedDate;
        var secondRead = country.UpdatedDate;

        // Assert
        Assert.NotEqual(firstRead, secondRead); // Should change on subsequent reads
    }
}