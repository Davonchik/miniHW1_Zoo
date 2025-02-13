using miniHW_1_AslanyanDG.Models.Animals;

namespace miniHW_1_AslanyanDG.Services.Interfaces;

/// <summary>
/// The public Veterinary Clinic interface.
/// </summary>
public interface IVeterinaryClinic
{
    bool CheckAnimal(Animal animal);
}