namespace miniHW_1_AslanyanDG.Models.Animals.Predators;

public abstract class Predator : Animal
{
    protected Predator(string name, uint food, uint health, uint number) : base(name, food, health, number) { }
}