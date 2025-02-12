using miniHW_1_AslanyanDG.Models.Animals;
using miniHW_1_AslanyanDG.Services.Interfaces;

namespace miniHW_1_AslanyanDG.Services;

public class VeterinaryClinic : IVeterinaryClinic
{
    public bool CheckAnimal(Animal animal)
    {
        Console.WriteLine($"\nПроводится осмотр животного: {animal.Name}");
        
        return animal.Health >= 5;
    }
}