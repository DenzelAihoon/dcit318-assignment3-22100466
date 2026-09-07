namespace Question1;

public class CryptoWalletProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine(
            $"Crypto Wallet processed: GHC{transaction.Amount} for {transaction.Category}"
        );
    }
}
