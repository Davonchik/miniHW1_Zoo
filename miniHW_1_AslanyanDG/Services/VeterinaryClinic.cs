using miniHW_1_AslanyanDG.Models.Animals;
using miniHW_1_AslanyanDG.Services.Interfaces;

namespace miniHW_1_AslanyanDG.Services;

/// <summary>
/// The public Veterinary Clinic class, IVeterinaryClinic inheritor.
/// </summary>
public class VeterinaryClinic : IVeterinaryClinic
{
    /// <summary>
    /// The public method for checking if animal is health.
    /// </summary>
    /// <param name="animal">Animal.</param>
    /// <returns>True or False.</returns>
    public bool CheckAnimal(Animal animal)
    {
        Console.WriteLine($"\nПроводится осмотр животного: {animal.Name}");
        
        return animal.Health >= 5;
    }
}