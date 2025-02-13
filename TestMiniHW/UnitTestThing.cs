using miniHW_1_AslanyanDG.Models.Inventory;

namespace miniHW_1_AslanyanDG.Tests;

public class UnitTestThing
{
    [Fact]
    public void CreateThingWithEmptyName_ShouldThrowArgumentNullException()
    {
        // Arrange
        uint number = 1;
        string invalidName = "";
            
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Thing(number, invalidName));
    }
}