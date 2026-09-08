namespace Question3;

public class InvalidQuantityException : Exception
{
    public InvalidQuantityException(string message)
        : base(message)
    {
    }
}
