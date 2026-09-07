namespace Question1;

public class FinanceApp
{
    private readonly List<Transaction> _transactions = new();

    public void Run()
    {
        // Create a savings account with an initial balance of GHC1000
        SavingsAccount account = new SavingsAccount("SA001", 1000m);

        // Create three transactions
        Transaction transaction1 = new Transaction(
            1,
            DateTime.Now,
            150m,
            "Groceries"
        );

        Transaction transaction2 = new Transaction(
            2,
            DateTime.Now,
            200m,
            "Utilities"
        );

        Transaction transaction3 = new Transaction(
            3,
            DateTime.Now,
            100m,
            "Entertainment"
        );

        // Create the transaction processors
        MobileMoneyProcessor mobileMoney = new MobileMoneyProcessor();
        BankTransferProcessor bankTransfer = new BankTransferProcessor();
        CryptoWalletProcessor cryptoWallet = new CryptoWalletProcessor();

        // Process each transaction
        mobileMoney.Process(transaction1);
        account.ApplyTransaction(transaction1);
        _transactions.Add(transaction1);

        bankTransfer.Process(transaction2);
        account.ApplyTransaction(transaction2);
        _transactions.Add(transaction2);

        cryptoWallet.Process(transaction3);
        account.ApplyTransaction(transaction3);
        _transactions.Add(transaction3);

        // Display account information
        Console.WriteLine();
        Console.WriteLine($"Account Number: {account.AccountNumber}");
        Console.WriteLine($"Final Balance: GHC{account.Balance}");
        Console.WriteLine($"Total Transactions: {_transactions.Count}");
    }
}

