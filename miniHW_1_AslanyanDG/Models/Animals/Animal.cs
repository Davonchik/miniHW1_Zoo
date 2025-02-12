using miniHW_1_AslanyanDG.Abstractions;

namespace miniHW_1_AslanyanDG.Models.Animals;

public abstract class Animal : IAlive, IInventory
{
    public uint Food { get; protected set; }
    public string Name { get; protected set; }
    
    public uint Health { get; protected set; }
    
    public uint Number { get; }

    public Animal(string name, uint food, uint health, uint number)
    {
        Name = name;
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "Вы не задали имя животному!");
        }
        Food = food;
        Health = health;
        Number = number;
    }

    public override string ToString() => $"{Name} (ID: {Number}) (Health: {Health})";
}