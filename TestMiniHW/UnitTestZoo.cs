using miniHW_1_AslanyanDG.Services.Interfaces;
using miniHW_1_AslanyanDG.Services;
using miniHW_1_AslanyanDG.Models.Animals;
using miniHW_1_AslanyanDG.Models.Animals.Herboes;
using miniHW_1_AslanyanDG.Models.Animals.Predators;
using miniHW_1_AslanyanDG.Models.Inventory;

namespace miniHW_1_AslanyanDG.Tests;

public class UnitTestZoo
{
    public class TestAnimal : Animal
    {
        public TestAnimal(string name, uint food, uint health, uint number)
            : base(name, food, health, number)
        {
        }
    }

    public class ZooTests
    {
        [Fact]
        public void AddAnimalWithSameNumber_ShouldShowLengthAnimalListEqual1()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);
            var animal1 = new TestAnimal("Rab", 3, 7, 505);
            var animal2 = new TestAnimal("Monkey", 6, 6, 505);
            
            // Act
            zoo.AddAnimal(animal1);
            zoo.AddAnimal(animal2);
            var animalsList = zoo.GetAnimals();
            
            // Assert
            Assert.Single(animalsList);
        }
        
        [Fact]
        public void AddAnimal_Success()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);
            var animal = new TestAnimal("Rab", 3, 7, 505);

            // Act
            zoo.AddAnimal(animal);
            var allAnimals = zoo.GetAnimals();

            // Assert
            Assert.Contains(animal, allAnimals);
        }

        [Fact]
        public void ShowInventory_ShouldListAnimalsAndThings()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);
            var tiger = new Tiger("tig", 10, 9, 100);
            var rabbit = new Rabbit("rab", 5, 8, 777, 10);
            var table = new Thing(8, "tableB");
            
            // Act
            zoo.AddAnimal(tiger);
            zoo.AddAnimal(rabbit);
            zoo.AddInventoryThing(table);

            // Assert
            using (var sw = new StringWriter())
            {
                var origOut = Console.Out;
                Console.SetOut(sw);
                
                zoo.ShowInventory();
                
                Console.SetOut(origOut);
                var output = sw.ToString();
                
                
                Assert.Contains("tableB", output);
                Assert.Contains("tig", output);
                Assert.Contains("rab", output);
            }
        }

        [Fact]
        public void AddInventoryThingWithDuplicatedNum_ShouldThrowException()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);
            var table = new Table(1, "table");
            var computer = new Computer(1, "comp");
            zoo.AddInventoryThing(table);
            
            // Act && Assert
            Assert.Throws<ArgumentException>(() => zoo.AddInventoryThing(computer));
        }

        [Fact]
        public void CreateHerboWithInvalidKindness_ShouldThrowException()
        {
            // Arrange && Act && Assert
            Assert.Throws<ArgumentException>(() => new Rabbit("Rab", 3, 7, 505, 11));
        }

        [Fact]
        public void CreateThingWithEmptyName_ShouldThrowArgumentNullException()
        {
            // Arrange
            uint number = 1;
            string invalidName = "";
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Thing(number, invalidName));
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

        [Fact]
        public void AddUnhealthyAnimal_ShouldNotBeAccepted()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);
            var sickAnimal = new TestAnimal("Больной тигр", 10, 3, 606);
            
            // Act
            zoo.AddAnimal(sickAnimal);
            var allAnimals = zoo.GetAnimals();

            // Assert
            Assert.DoesNotContain(sickAnimal, allAnimals);
        }

        [Fact]
        public void GetTotalFoodRequirement_ShouldReturnCorrectSum()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);
            zoo.AddAnimal(new Tiger("Тигр", 10, 8, 1));
            zoo.AddAnimal(new Wolf("Волк", 7, 9, 2));
            zoo.AddAnimal(new Rabbit("Кролик", 3, 10, 3, 6));

            // Act
            var totalFood = zoo.GetTotalFoodRequirement();

            // Assert
            Assert.Equal(20u, totalFood);
        }

        [Fact]
        public void GetContactZooAnimals_ShouldReturnOnlyFriendlyHerbivores()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);
            var rabbit = new Rabbit("Дружелюбный кролик", 3, 10, 100, 7);
            var monkey = new Monkey("Обезьяна", 4, 10, 101, 6);
            var tiger = new Tiger("Тигр", 12, 10, 102);

            zoo.AddAnimal(rabbit);
            zoo.AddAnimal(monkey);
            zoo.AddAnimal(tiger);

            // Act
            var contactAnimals = zoo.GetContactZooAnimals();

            // Assert
            Assert.Equal(2, contactAnimals.Count());
            Assert.Contains(rabbit, contactAnimals);
            Assert.Contains(monkey, contactAnimals);
            Assert.DoesNotContain(tiger, contactAnimals);
        }

        [Fact]
        public void AddAnimal_ZeroHealth_ShouldNotAdd()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);

            // Act
            var wolf = new Wolf("weakWolf", 40, 0, 606);
            zoo.AddAnimal(wolf);
            
            // Assert
            Assert.DoesNotContain(wolf, zoo.GetAnimals());
        }

        [Fact]
        public void EmptyZoo_ShouldHaveZeroFoodAndNoAnimals()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);
            
            // Act
            var allAnimals = zoo.GetAnimals();
            var totalFood = zoo.GetTotalFoodRequirement();
            var contactAnimals = zoo.GetContactZooAnimals();
            
            // Assert
            Assert.Empty(allAnimals);
            Assert.Equal((uint)0, totalFood);
            Assert.Empty(contactAnimals);
        }
    }
}
