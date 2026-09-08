using Question5;

string filePath = "inventory.json";

// First session
InventoryApp app = new InventoryApp(filePath);

app.SeedSampleData();

Console.WriteLine("=== SAVING DATA ===");
app.SaveData();

// New session
Console.WriteLine();
Console.WriteLine("=== NEW SESSION ===");

InventoryApp newApp = new InventoryApp(filePath);

newApp.LoadData();

Console.WriteLine();
newApp.PrintAllItems();
