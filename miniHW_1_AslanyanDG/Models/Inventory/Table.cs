namespace miniHW_1_AslanyanDG.Models.Inventory;

/// <summary>
/// The Table class, Thing inheritor.
/// </summary>
public class Table : Thing
{
    /// <summary>
    /// Table constructor.
    /// </summary>
    /// <param name="number">Table's id.</param>
    /// <param name="name">Table's name.</param>
    public Table(uint number, string name) : base(number, name) { }
}