using miniHW_1_AslanyanDG.Models.Animals;
using miniHW_1_AslanyanDG.Models.Animals.Herboes;
using miniHW_1_AslanyanDG.Models.Inventory;
using miniHW_1_AslanyanDG.Services.Interfaces;
using miniHW_1_AslanyanDG.Abstractions;

namespace miniHW_1_AslanyanDG.Services;

public class Zoo : IZoo
{
    private readonly List<Animal> animals = new List<Animal>();
    private readonly List<IInventory> inventoryItems = new List<IInventory>();
    private readonly IVeterinaryClinic vetClinic;

    public Zoo(IVeterinaryClinic vetClinic)
    {
        this.vetClinic = vetClinic;
    }
    
    public void AddAnimal(Animal animal)
    {
        if (animals.Any(a => a.Number == animal.Number))
        {
            Console.WriteLine($"Животное с номером {animal.Number} уже в зоопарке!");
            return;
        }

        var isHealthy = vetClinic.CheckAnimal(animal);

        if (!isHealthy)
        {
            Console.WriteLine($"Животное {animal.Name} не прошло проверку и не принято в зоопарк.");
            return;
        }

        animals.Add(animal);
        inventoryItems.Add(animal);
        Console.WriteLine($"Животное {animal.Name} успешно принято в зоопарк.");
    }

    public IEnumerable<Animal> GetAnimals() => animals;
    public uint GetTotalFoodRequirement() => (uint)animals.Sum(a => a.Food);
    
    public IEnumerable<Animal> GetContactZooAnimals() =>
        animals.Where(a => a is Herbo herbivore && herbivore.Kindness > 5);
    
    public void ShowInventory()
    {
        Console.WriteLine("\nИнвентаризационные объекты зоопарка:");
        foreach (var item in inventoryItems)
        {
            switch (item)
            {
                case Thing thing:
                    Console.WriteLine($"Вещь: {thing.Name}, инвентарный номер: {thing.Number}");
                    break;
                case Animal animal:
                    Console.WriteLine($"Животное: {animal.Name}, инвентарный номер: {animal.Number}");
                    break;
                default:
                    Console.WriteLine($"Неизвестный тип инвентаря: {item.GetType().Name}");
                    break;
            }
        }
    }

    public void AddInventoryItem(IInventory item) => inventoryItems.Add(item);
}
