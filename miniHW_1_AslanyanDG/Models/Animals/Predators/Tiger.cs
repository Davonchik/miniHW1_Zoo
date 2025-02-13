namespace miniHW_1_AslanyanDG.Models.Animals.Predators;

/// <summary>
/// The public Tiger class, Predator inheritor.
/// </summary>
public class Tiger : Predator
{
    /// <summary>
    /// Tiger constructor.
    /// </summary>
    /// <param name="name">Tiger's name.</param>
    /// <param name="food">Tiger's food amount.</param>
    /// <param name="health">Tiger's health level.</param>
    /// <param name="number">Tiger's id.</param>
    public Tiger(string name, uint food, uint health, uint number) : base(name, food, health, number) { }
}