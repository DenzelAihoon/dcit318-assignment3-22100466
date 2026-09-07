namespace Question1;

public class MobileMoneyProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine(
            $"Mobile Money processed: GHC{transaction.Amount} for {transaction.Category}"
        );
    }
}
