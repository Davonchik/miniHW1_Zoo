namespace miniHW_1_AslanyanDG.Models.Animals.Herboes;

/// <summary>
/// The public Monkey class, Herbo's inheritor.
/// </summary>
public class Monkey : Herbo
{
    /// <summary>
    /// Monkey constructor.
    /// </summary>
    /// <param name="name">Monkey's name.</param>
    /// <param name="food">Monkey's food amount.</param>
    /// <param name="health">Monkey's health level.</param>
    /// <param name="number">Monkey's id.</param>
    /// <param name="kindness">Monkey's kindness level.</param>
    public Monkey(string name, uint food, uint health, uint number, uint kindness) 
        : base(name, food, health, number, kindness) { }
}