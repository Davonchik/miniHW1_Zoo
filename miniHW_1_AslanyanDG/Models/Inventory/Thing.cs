using miniHW_1_AslanyanDG.Abstractions;

namespace miniHW_1_AslanyanDG.Models.Inventory;

/// <summary>
/// The public Thing class.
/// </summary>
public class Thing : IInventory
{
    public uint Number { get; protected set; }
    public string Name { get; protected set; }
    
    /// <summary>
    /// The public virtual method for showing things info. The IInventory method realisation.
    /// </summary>
    public virtual void ShowInventoryInfo()
    {
        Console.WriteLine($"Вещь: {Name}, инвентарный номер: {Number}");
    }

    /// <summary>
    /// Thing constructor.
    /// </summary>
    /// <param name="number">Thing's id.</param>
    /// <param name="name">Thing's name.</param>
    public Thing(uint number, string name)
    {
        Number = number;
        Name = name;
    }
}