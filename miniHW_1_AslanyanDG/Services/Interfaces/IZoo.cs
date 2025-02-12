using miniHW_1_AslanyanDG.Models.Animals;
using miniHW_1_AslanyanDG.Abstractions;

namespace miniHW_1_AslanyanDG.Services.Interfaces;

public interface IZoo
{
    void AddAnimal(Animal animal);
    IEnumerable<Animal> GetAnimals();
    uint GetTotalFoodRequirement();
    IEnumerable<Animal> GetContactZooAnimals();
    void ShowInventory();
    void AddInventoryItem(IInventory item);
}
