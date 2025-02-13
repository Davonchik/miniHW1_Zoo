using miniHW_1_AslanyanDG.Abstractions;

namespace miniHW_1_AslanyanDG.Models.Animals;

/// <summary>
/// The public abstract Animal class, IAlive and IInventory inheritor.
/// </summary>
public abstract class Animal : IAlive, IInventory
{
    public uint Food { get; protected set; }
    public string Name { get; protected set; }
    public uint Health { get; protected set; }
    public uint Number { get; }
    
    /// <summary>
    /// The public virtual method for showing animal's info. The IInventory method realisation.
    /// </summary>
    public virtual void ShowInventoryInfo()
    {
        Console.WriteLine($"Животное: {Name}, инвентарный номер: {Number}");
    }

    /// <summary>
    /// Animal constructor.
    /// </summary>
    /// <param name="name">Animal's name.</param>
    /// <param name="food">Animal's food amount.</param>
    /// <param name="health">Animal's health level.</param>
    /// <param name="number">Animal's id.</param>
    /// <exception cref="ArgumentNullException">Incorrect Animal's name exception.</exception>
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

    /// <summary>
    /// The override output method.
    /// </summary>
    /// <returns>Format string.</returns>
    public override string ToString() => $"{Name} (ID: {Number}) (Health: {Health})";
}