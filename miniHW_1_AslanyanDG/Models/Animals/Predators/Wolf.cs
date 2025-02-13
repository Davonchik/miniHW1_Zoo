namespace miniHW_1_AslanyanDG.Models.Animals.Predators;

/// <summary>
/// The public Wolf class, Predator inheritor.
/// </summary>
public class Wolf : Predator
{
    /// <summary>
    /// Wolf constructor.
    /// </summary>
    /// <param name="name">Wolf's name.</param>
    /// <param name="food">Wolf's food amount.</param>
    /// <param name="health">Wolf's health level.</param>
    /// <param name="number">Wolf's id.</param>
    public Wolf(string name, uint food, uint health, uint number) : base(name, food, health, number) { }
}