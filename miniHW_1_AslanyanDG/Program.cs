using miniHW_1_AslanyanDG.Services;
using miniHW_1_AslanyanDG.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using miniHW_1_AslanyanDG.Models.Animals;
using miniHW_1_AslanyanDG.Models.Animals.Herboes;
using miniHW_1_AslanyanDG.Models.Animals.Predators;


namespace miniHW_1_AslanyanDG;

public class Program
{
    public static void Main(string[] args)
    {
        // Настройка DI-контейнера
        var serviceProvider = new ServiceCollection()
            .AddScoped<IVeterinaryClinic, VeterinaryClinic>()
            .AddScoped<IZoo, Zoo>()
            .BuildServiceProvider();

        var zoo = serviceProvider.GetService<IZoo>();

        var exit = false;
        while (!exit)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить животное");
            Console.WriteLine("2. Показать список животных и общее потребление еды");
            Console.WriteLine("3. Показать животных для контактного зоопарка");
            Console.WriteLine("4. Показать инвентаризационные объекты");
            Console.WriteLine("5. Выход");
            Console.Write("Ваш выбор: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddAnimalMenu(zoo);
                    break;
                case "2":
                    ShowSummary(zoo);
                    break;
                case "3":
                    ShowContactAnimals(zoo);
                    break;
                case "4":
                    zoo.ShowInventory();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                    break;
            }
        }
    }

    // Меню для добавления нового животного
    static void AddAnimalMenu(IZoo zoo)
    {
        try
        {
            Console.WriteLine("\nВыберите тип животного:");
            Console.WriteLine("1. Кролик");
            Console.WriteLine("2. Тигр");
            Console.WriteLine("3. Волк");
            Console.WriteLine("4. Обезьяна");
            Console.Write("Ваш выбор: ");
            var typeChoice = Console.ReadLine();

            Console.Write("Введите имя животного: ");
            var name = Console.ReadLine();

            Console.Write("Введите количество кг еды в сутки: ");
            uint food;

            if (!uint.TryParse(Console.ReadLine(), out food))
            {
                throw new FormatException("Было введено некорректное число килограмм!");
            }
            
            Console.Write("Введите уровень здоровья животного: ");
            uint health;

            if (!uint.TryParse(Console.ReadLine(), out health))
            {
                throw new FormatException("Было введено некорректное число здоровья!");
            }
            
            Console.Write("Введите номер животному: ");
            uint num;
            
            if (!uint.TryParse(Console.ReadLine(), out num))
            {
                throw new FormatException("Животному был присвоен некорректный номер!");
            }

            Animal animal = null;
            switch (typeChoice)
            {
                case "1":   // Кролик – травоядное животное
                    Console.Write("Введите уровень доброты: ");
                    var kindnessRabbit = uint.Parse(Console.ReadLine());
                    animal = new Rabbit(name, food, health, num, kindnessRabbit);
                    break;
                case "2":   // Тигр – хищное животное
                    animal = new Tiger(name, food, health, num);
                    break;
                case "3":   // Волк – хищное животное
                    animal = new Wolf(name, food, health, num);
                    break;
                case "4":   // Обезьяна – травоядное животное для контактного зоопарка
                    Console.Write("Введите уровень доброты: ");
                    var kindnessMonkey = uint.Parse(Console.ReadLine());
                    animal = new Monkey(name, food, health, num, kindnessMonkey);
                    break;
                default:
                    Console.WriteLine("Неверный выбор типа животного.");
                    break;
            }
            if (animal != null)
            {
                zoo.AddAnimal(animal);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    static void ShowSummary(IZoo zoo)
    {
        try
        {
            var animals = zoo.GetAnimals();
            Console.WriteLine("\nСписок животных в зоопарке:");
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
            Console.WriteLine($"\nОбщее количество животных: {animals.Count()}");
            Console.WriteLine($"Суммарное потребление еды: {zoo.GetTotalFoodRequirement()} кг/сутки");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Вывод животных, пригодных для контактного зоопарка
    static void ShowContactAnimals(IZoo zoo)
    {
        try
        {
            Console.WriteLine("\nЖивотные, пригодные для контактного зоопарка:");
            var contactAnimals = zoo.GetContactZooAnimals();
            foreach (var animal in contactAnimals)
            {
                Console.WriteLine(animal);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}