namespace Question3;

public class InventoryRepository<T> where T : IInventoryItem
{
    private readonly Dictionary<int, T> _items = new();

    public void AddItem(T item)
    {
        if (_items.ContainsKey(item.Id))
        {
            throw new DuplicateItemException(
                $"Item with ID {item.Id} already exists."
            );
        }

        _items.Add(item.Id, item);
    }

    public T GetItemById(int id)
    {
        if (!_items.ContainsKey(id))
        {
            throw new ItemNotFoundException(
                $"Item with ID {id} was not found."
            );
        }

        return _items[id];
    }

    public void RemoveItem(int id)
    {
        if (!_items.ContainsKey(id))
        {
            throw new ItemNotFoundException(
                $"Item with ID {id} was not found."
            );
        }

        _items.Remove(id);
    }

    public List<T> GetAllItems()
    {
        return _items.Values.ToList();
    }

    public void UpdateQuantity(int id, int newQuantity)
    {
        if (newQuantity < 0)
        {
            throw new InvalidQuantityException(
                "Quantity cannot be negative."
            );
        }

        T item = GetItemById(id);
        item.Quantity = newQuantity;
    }
}
