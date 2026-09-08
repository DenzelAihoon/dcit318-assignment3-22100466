namespace Question5;

public class InventoryApp
{
    private readonly InventoryLogger<InventoryItem> _logger;

    public InventoryApp(string filePath)
    {
        _logger = new InventoryLogger<InventoryItem>(filePath);
    }

    public void SeedSampleData()
    {
        _logger.Add(
            new InventoryItem(
                1,
                "Laptop",
                10,
                DateTime.Now.AddDays(-5)
            )
        );

        _logger.Add(
            new InventoryItem(
                2,
                "Keyboard",
                25,
                DateTime.Now.AddDays(-3)
            )
        );

        _logger.Add(
            new InventoryItem(
                3,
                "Mouse",
                30,
                DateTime.Now
            )
        );

        _logger.Add(
            new InventoryItem(
                4,
                "Monitor",
                8,
                DateTime.Now.AddDays(-1)
            )
        );
    }

    public void SaveData()
    {
        _logger.SaveToFile();
    }

    public void LoadData()
    {
        _logger.LoadFromFile();
    }

    public void PrintAllItems()
    {
        Console.WriteLine("=== INVENTORY ITEMS ===");

        foreach (InventoryItem item in _logger.GetAll())
        {
            Console.WriteLine(
                $"ID: {item.Id}, " +
                $"Name: {item.Name}, " +
                $"Quantity: {item.Quantity}, " +
                $"Date Added: {item.DateAdded:d}"
            );
        }
    }
}
