namespace Question1;

public class BankTransferProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine(
            $"Bank Transfer processed: GHC{transaction.Amount} for {transaction.Category}"
        );
    }
}
