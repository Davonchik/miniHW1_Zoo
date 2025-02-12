using miniHW_1_AslanyanDG.Abstractions;

namespace miniHW_1_AslanyanDG.Models.Inventory;

public class Thing : IInventory
{
    public uint Number { get; protected set; }
    public string Name { get; protected set; }

    public Thing(uint number, string name)
    {
        Number = number;
        Name = name;
    }
}