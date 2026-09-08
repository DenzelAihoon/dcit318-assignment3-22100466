using Question3;

WareHouseManager manager = new WareHouseManager();

manager.SeedData();

Console.WriteLine("=== ELECTRONIC ITEMS ===");
manager.PrintAllItems(manager.GetElectronics());

Console.WriteLine();
Console.WriteLine("=== GROCERY ITEMS ===");
manager.PrintAllItems(manager.GetGroceries());

Console.WriteLine();
Console.WriteLine("=== INCREASING STOCK ===");

manager.IncreaseStock(1, 5);

Console.WriteLine("Laptop stock increased.");

Console.WriteLine();
Console.WriteLine("=== UPDATED ELECTRONIC ITEMS ===");
manager.PrintAllItems(manager.GetElectronics());

Console.WriteLine();
Console.WriteLine("=== TESTING DUPLICATE ITEM ===");

try
{
    manager.GetElectronics().AddItem(
        new ElectronicItem(
            1,
            "Another Laptop",
            5,
            "HP",
            12
        )
    );
}
catch (DuplicateItemException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("=== TESTING MISSING ITEM ===");

manager.RemoveItemById(99);

Console.WriteLine();
Console.WriteLine("=== TESTING INVALID QUANTITY ===");

try
{
    manager.GetGroceries().UpdateQuantity(3, -10);
}
catch (InvalidQuantityException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("=== REMOVING ITEM ===");

manager.RemoveItemById(4);

Console.WriteLine("Item with ID 4 removed.");

Console.WriteLine();
Console.WriteLine("=== FINAL GROCERY ITEMS ===");
manager.PrintAllItems(manager.GetGroceries());
