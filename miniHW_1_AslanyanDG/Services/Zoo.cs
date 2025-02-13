using miniHW_1_AslanyanDG.Models.Animals;
using miniHW_1_AslanyanDG.Models.Animals.Herboes;
using miniHW_1_AslanyanDG.Models.Inventory;
using miniHW_1_AslanyanDG.Services.Interfaces;
using miniHW_1_AslanyanDG.Abstractions;

namespace miniHW_1_AslanyanDG.Services;

public class Zoo(IVeterinaryClinic vetClinic) : IZoo
{
    private readonly List<Animal> _animals = new();
    private readonly List<IInventory> _inventoryItems = new();

    public void AddAnimal(Animal animal)
    {
        if (_animals.Any(a => a.Number == animal.Number))
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

        _animals.Add(animal);
        _inventoryItems.Add(animal);
        Console.WriteLine($"Животное {animal.Name} успешно принято в зоопарк.");
    }

    public IEnumerable<Animal> GetAnimals() => _animals.AsReadOnly();
    public uint GetTotalFoodRequirement() => (uint)_animals.Sum(a => a.Food);
    
    public IEnumerable<Animal> GetContactZooAnimals() =>
        _animals.Where(a => a is Herbo { Kindness: > 5 }).ToList().AsReadOnly();
    
    public void ShowInventory()
    {
        Console.WriteLine("\nИнвентаризационные объекты зоопарка:");
        foreach (var item in _inventoryItems)
        {
            item.ShowInventoryInfo();
        }
    }

    public void AddInventoryThing(Thing item)
    {
        if (_inventoryItems.Any(a => a.Number == item.Number))
        {
            throw new ArgumentException("Инвентарь с данным номером уже существует!");
        }
        _inventoryItems.Add(item);
        Console.WriteLine($"Предмет {item.Name} был добавлен в инвентарь!");
    }
}
