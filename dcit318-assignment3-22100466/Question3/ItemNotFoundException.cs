namespace Question3;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException(string message)
        : base(message)
    {
    }
}
