using miniHW_1_AslanyanDG.Models.Animals;
using miniHW_1_AslanyanDG.Models.Inventory;

namespace miniHW_1_AslanyanDG.Services.Interfaces;

/// <summary>
/// The public Zoo interface.
/// </summary>
public interface IZoo
{
    void AddAnimal(Animal animal);
    IEnumerable<Animal> GetAnimals();
    uint GetTotalFoodRequirement();
    IEnumerable<Animal> GetContactZooAnimals();
    void ShowInventory();
    void AddInventoryThing(Thing item);
}
