namespace miniHW_1_AslanyanDG.Models.Animals.Herboes;

public abstract class Herbo : Animal
{
    public uint Kindness { get; protected set; }

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