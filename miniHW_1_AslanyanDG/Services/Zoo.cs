using miniHW_1_AslanyanDG.Models.Animals;
using miniHW_1_AslanyanDG.Models.Animals.Herboes;
using miniHW_1_AslanyanDG.Models.Inventory;
using miniHW_1_AslanyanDG.Services.Interfaces;
using miniHW_1_AslanyanDG.Abstractions;

namespace miniHW_1_AslanyanDG.Services;

/// <summary>
/// The public Zoo class, IZoo inheritor.
/// </summary>
/// <param name="vetClinic">vetClinic is aggregated to zoo.</param>
public class Zoo(IVeterinaryClinic vetClinic) : IZoo
{
    // Protected to rewrite the value (usage of readonly).
    private readonly List<Animal> _animals = new();
    private readonly List<IInventory> _inventoryItems = new();

    /// <summary>
    /// The animal addition method.
    /// </summary>
    /// <param name="animal">Animal.</param>
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

    /// <summary>
    /// Get animals public IEnumerable method.
    /// </summary>
    /// <returns>Protected from external changes list of animals.</returns>
    public IEnumerable<Animal> GetAnimals() => _animals.AsReadOnly();
    
    /// <summary>
    /// Get total food summary.
    /// </summary>
    /// <returns>Total sum of kilograms from all animals.</returns>
    public uint GetTotalFoodRequirement() => (uint)_animals.Sum(a => a.Food);
    
    /// <summary>
    /// Get animals for contact zoo public IEnumerable method.
    /// </summary>
    /// <returns>Protected from external changes list of animals for contact zoo.</returns>
    public IEnumerable<Animal> GetContactZooAnimals() =>
        _animals.Where(a => a is Herbo { Kindness: > 5 }).ToList().AsReadOnly();
    
    /// <summary>
    /// The show inventory method.
    /// </summary>
    public void ShowInventory()
    {
        Console.WriteLine("\nИнвентаризационные объекты зоопарка:");
        foreach (var item in _inventoryItems)
        {
            item.ShowInventoryInfo();
        }
    }

    /// <summary>
    /// The thing addition method.
    /// </summary>
    /// <param name="item">Thing.</param>
    /// <exception cref="ArgumentException">Argument Exception if such thing exists.</exception>
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
