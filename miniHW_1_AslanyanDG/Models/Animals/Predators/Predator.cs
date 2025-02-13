namespace miniHW_1_AslanyanDG.Models.Animals.Predators;

/// <summary>
/// The predator animals abstract class, Animal inheritor.
/// </summary>
public abstract class Predator : Animal
{
    /// <summary>
    /// Predator constructor.
    /// </summary>
    /// <param name="name">Predator name.</param>
    /// <param name="food">Predator food amount.</param>
    /// <param name="health">Predator health level.</param>
    /// <param name="number">Predator id.</param>
    protected Predator(string name, uint food, uint health, uint number) : base(name, food, health, number) { }
}