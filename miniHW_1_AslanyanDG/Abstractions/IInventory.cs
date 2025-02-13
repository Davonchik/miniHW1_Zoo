namespace miniHW_1_AslanyanDG.Abstractions;

/// <summary>
/// The public interface for inventory.
/// </summary>
public interface IInventory
{
    uint Number { get; }

    void ShowInventoryInfo();
}