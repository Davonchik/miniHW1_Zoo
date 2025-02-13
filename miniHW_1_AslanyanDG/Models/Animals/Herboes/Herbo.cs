namespace miniHW_1_AslanyanDG.Models.Animals.Herboes;


/// <summary>
/// The herbivore animals abstract class, Animal inheritor.
/// </summary>
public abstract class Herbo : Animal
{
    // Kindness property.
    public uint Kindness { get; protected set; }

    /// <summary>
    /// Constructor for Herbivore.
    /// </summary>
    /// <param name="name">Herbivore name.</param>
    /// <param name="food">Herbivore food amount.</param>
    /// <param name="health">Herbivore health level.</param>
    /// <param name="number">Herbivore id.</param>
    /// <param name="kindness">Herbivore kindness level.</param>
    /// <exception cref="ArgumentException">Kindness not in [1; 10]</exception>
    protected Herbo(string name, uint food, uint health, uint number, uint kindness) 
        : base(name, food, health, number)
    {
        if (kindness is > 10 or < 1)
        {
            throw new ArgumentException("Уровень доброты должен быть между 1 и 10!", nameof(kindness));
        }
        Kindness = kindness;
    }
}