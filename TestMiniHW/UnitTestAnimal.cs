using miniHW_1_AslanyanDG.Models.Animals.Herboes;

namespace miniHW_1_AslanyanDG.Tests;

public class UnitTestAnimal
{
    [Fact]
    public void CreateHerboWithInvalidKindness_ShouldThrowException()
    {
        // Arrange && Act && Assert
        Assert.Throws<ArgumentException>(() => new Rabbit("Rab", 3, 7, 505, 11));
    }
    
    [Fact]
    public void CreateAnimalWithEmptyName_ShouldThrowArgumentNullException()
    {
        // Arrange
        string invalidName = "";
        uint food = 10;
        uint health = 100;
        uint number = 1;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new TestAnimal(invalidName, food, health, number));
    }
    
    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        // Arrange
        string name = "Bars";
        uint food = 20;
        uint health = 100;
        uint number = 101;
        var animal = new TestAnimal(name, food, health, number);

        // Act
        string result = animal.ToString();

        // Assert
        Assert.Equal("Bars (ID: 101) (Health: 100)", result);
    }
}