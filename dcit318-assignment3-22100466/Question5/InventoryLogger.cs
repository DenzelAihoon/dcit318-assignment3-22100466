using System.Text.Json;

namespace Question5;

public class InventoryLogger<T> where T : IInventoryEntity
{
    private readonly List<T> _log = new();
    private readonly string _filePath;

    public InventoryLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(T item)
    {
        _log.Add(item);
    }

    public List<T> GetAll()
    {
        return _log;
    }

    public void SaveToFile()
    {
        try
        {
            string json = JsonSerializer.Serialize(
                _log,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.Write(json);
            }

            Console.WriteLine("Inventory data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Error saving inventory data: {ex.Message}"
            );
        }
    }

    public void LoadFromFile()
    {
        try
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string json = reader.ReadToEnd();

                List<T>? loadedItems =
                    JsonSerializer.Deserialize<List<T>>(json);

                if (loadedItems != null)
                {
                    _log.Clear();
                    _log.AddRange(loadedItems);
                }
            }

            Console.WriteLine("Inventory data loaded successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Inventory file was not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Error loading inventory data: {ex.Message}"
            );
        }
    }
}
