namespace Question2;

public class Repository<T>
{
    private readonly List<T> items = new();

    public void Add(T item)
    {
        items.Add(item);
    }

    public List<T> GetAll()
    {
        return items;
    }

    public T? GetById(Func<T, bool> predicate)
    {
        return items.FirstOrDefault(predicate);
    }

    public void Remove(Func<T, bool> predicate)
    {
        T? item = items.FirstOrDefault(predicate);

        if (item != null)
        {
            items.Remove(item);
        }
    }
}
