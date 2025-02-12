using miniHW_1_AslanyanDG.Services.Interfaces;
using miniHW_1_AslanyanDG.Services;
using miniHW_1_AslanyanDG.Models.Animals;
using miniHW_1_AslanyanDG.Models.Animals.Herboes;
using miniHW_1_AslanyanDG.Models.Animals.Predators;

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
        //     var animal = new TestAnimal("Rab", 3, 10, 505); // Должно пройти проверку здоровья
        //
        //     using (var sw = new StringWriter())
        //     {
        //         var originalConsoleOut = Console.Out;
        //         try
        //         {
        //             Console.SetOut(sw);
        //
        //             zoo.AddAnimal(animal); // Первый вызов - должно добавиться
        //             zoo.AddAnimal(animal); // Второй вызов - должно напечатать "уже в зоопарке"
        //
        //             Console.Out.Flush();
        //
        //             string consoleOutput = sw.ToString();
        //             
        //             // DEBUG: Вывести реальный вывод консоли
        //             if (string.IsNullOrWhiteSpace(consoleOutput))
        //             {
        //                 throw new Exception("ОШИБКА: Вывод в консоль пуст, возможно, Console.WriteLine() не вызывается!");
        //             }
        //             
        //             Assert.Contains($"Животное с номером {animal.Number} уже в зоопарке!", consoleOutput);
        //         }
        //         finally
        //         {
        //             Console.SetOut(originalConsoleOut);
        //         }
        //     }
        // }

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
    }
}
