namespace Question3;

public class WareHouseManager
{
    private readonly InventoryRepository<ElectronicItem> electronics =
        new();

    private readonly InventoryRepository<GroceryItem> groceries =
        new();

    public void SeedData()
    {
        electronics.AddItem(
            new ElectronicItem(
                1,
                "Laptop",
                10,
                "Dell",
                24
            )
        );

        electronics.AddItem(
            new ElectronicItem(
                2,
                "Smartphone",
                15,
                "Samsung",
                12
            )
        );

        groceries.AddItem(
            new GroceryItem(
                3,
                "Milk",
                20,
                DateTime.Now.AddDays(7)
            )
        );

        groceries.AddItem(
            new GroceryItem(
                4,
                "Bread",
                30,
                DateTime.Now.AddDays(3)
            )
        );
    }

    public void PrintAllItems<T>(InventoryRepository<T> repository)
        where T : IInventoryItem
    {
        foreach (T item in repository.GetAllItems())
        {
            Console.WriteLine(
                $"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}"
            );
        }
    }

    public void IncreaseStock(int id, int amount)
    {
        try
        {
            ElectronicItem? electronic = null;

            try
            {
                electronic = electronics.GetItemById(id);
            }
            catch (ItemNotFoundException)
            {
                // Not an electronic item
            }

            if (electronic != null)
            {
                electronics.UpdateQuantity(
                    id,
                    electronic.Quantity + amount
                );

                return;
            }

            GroceryItem? grocery = null;

            try
            {
                grocery = groceries.GetItemById(id);
            }
            catch (ItemNotFoundException)
            {
                // Not a grocery item
            }

            if (grocery != null)
            {
                groceries.UpdateQuantity(
                    id,
                    grocery.Quantity + amount
                );

                return;
            }

            throw new ItemNotFoundException(
                $"Item with ID {id} was not found."
            );
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void RemoveItemById(int id)
    {
        try
        {
            try
            {
                electronics.RemoveItem(id);
                return;
            }
            catch (ItemNotFoundException)
            {
                // Try groceries
            }

            groceries.RemoveItem(id);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public InventoryRepository<ElectronicItem> GetElectronics()
    {
        return electronics;
    }

    public InventoryRepository<GroceryItem> GetGroceries()
    {
        return groceries;
    }
}
