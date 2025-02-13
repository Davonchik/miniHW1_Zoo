namespace miniHW_1_AslanyanDG.Models.Animals.Herboes;

/// <summary>
/// The public Rabbit class, Herbo's inheritor.
/// </summary>
public class Rabbit : Herbo
{
    /// <summary>
    /// Rabbit constructor.
    /// </summary>
    /// <param name="name">Rabbit's name.</param>
    /// <param name="food">Rabbit's food amount.</param>
    /// <param name="health">Rabbit's health level.</param>
    /// <param name="number">Rabbit's id.</param>
    /// <param name="kindness">Rabbit's kindness level.</param>
    public Rabbit(string name, uint food, uint health, uint number, uint kindness) 
        : base(name, food, health, number, kindness) { }
}
