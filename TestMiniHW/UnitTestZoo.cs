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
        
        

        // [Fact]
        // public void AnimalAlreadyExists_Message()
        // {
        //     // Arrange
        //     IVeterinaryClinic clinic = new VeterinaryClinic();
        //     IZoo zoo = new Zoo(clinic);
        //
        //     var animal1 = new Wolf("wolf1", 5, 8, 777);
        //     var animal2 = new Wolf("wolf2", 4, 8, 777);
        //
        //     using (var sw = new StringWriter())
        //     {
        //         var origOut = Console.Out;
        //         try
        //         {
        //             Console.SetOut(sw);
        //
        //             zoo.AddAnimal(animal1);
        //             zoo.AddAnimal(animal2);
        //         }
        //         finally
        //         {
        //             Console.SetOut(origOut);
        //         }
        //
        //         var output = sw.ToString();
        //         
        //         Assert.Contains("Wolf 1 was successfully added", output);
        //         var allAnimals = zoo.GetAnimals();
        //         Assert.Single(allAnimals);
        //         Assert.Contains(animal1, allAnimals);
        //     }
        // }

        [Fact]
        public void ShowInventory_ShouldListAnimalsAndThings()
        {
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);

            var tiger = new Tiger("tig", 10, 9, 100);
            zoo.AddAnimal(tiger);
            
            var rabbit = new Rabbit("rab", 5, 8, 777, 10);
            zoo.AddAnimal(rabbit);

            var table = new Thing(8, "tableB");
            zoo.AddInventoryThing(table);

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
        public void AddUnhealthyAnimal_ShouldNotBeAccepted()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);
            var sickAnimal = new TestAnimal("Больной тигр", 10, 3, 606); // Health < 5
            
            // Act
            zoo.AddAnimal(sickAnimal);
            var allAnimals = zoo.GetAnimals();

            // Assert
            Assert.DoesNotContain(sickAnimal, allAnimals); // Больное животное не должно попасть в зоопарк
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
            Assert.Equal(20u, totalFood); // 10 + 7 + 3 = 20
        }

        [Fact]
        public void GetContactZooAnimals_ShouldReturnOnlyFriendlyHerbivores()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);
            var rabbit = new Rabbit("Дружелюбный кролик", 3, 10, 100, 7); // Доброта > 5
            var monkey = new Monkey("Обезьяна", 4, 10, 101, 6); // Доброта > 5
            var tiger = new Tiger("Тигр", 12, 10, 102); // Хищник, не попадает

            zoo.AddAnimal(rabbit);
            zoo.AddAnimal(monkey);
            zoo.AddAnimal(tiger);

            // Act
            var contactAnimals = zoo.GetContactZooAnimals();

            // Assert
            Assert.Equal(2, contactAnimals.Count()); // Только rabbit и monkey подходят
            Assert.Contains(rabbit, contactAnimals);
            Assert.Contains(monkey, contactAnimals);
            Assert.DoesNotContain(tiger, contactAnimals);
        }

        [Fact]
        public void AddAnimal_ZeroHealth_ShouldNotAdd()
        {
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);

            var wolf = new Wolf("weakWolf", 40, 0, 606);
            zoo.AddAnimal(wolf);
            
            Assert.DoesNotContain(wolf, zoo.GetAnimals());
        }

        [Fact]
        public void EmptyZoo_ShouldHaveZeroFoodAndNoAnimals()
        {
            IVeterinaryClinic clinic = new VeterinaryClinic();
            IZoo zoo = new Zoo(clinic);
            
            var allAnimals = zoo.GetAnimals();
            var totalFood = zoo.GetTotalFoodRequirement();
            var contactAnimals = zoo.GetContactZooAnimals();
            
            Assert.Empty(allAnimals);
            Assert.Equal((uint)0, totalFood);
            Assert.Empty(contactAnimals);
        }
    }
}
