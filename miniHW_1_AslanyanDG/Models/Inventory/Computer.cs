namespace miniHW_1_AslanyanDG.Models.Inventory;

/// <summary>
/// The Computer class, Thing inheritor.
/// </summary>
public class Computer : Thing
{
    /// <summary>
    /// Computer constructor.
    /// </summary>
    /// <param name="number">Computer's id.</param>
    /// <param name="name">Computer's name.</param>
    public Computer(uint number, string name) : base(number, name) { }
}