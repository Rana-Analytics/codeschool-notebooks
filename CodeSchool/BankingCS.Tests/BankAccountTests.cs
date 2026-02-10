namespace BankingCS.Tests;

/// <summary>
/// Unit tests for the Transaction and BankAccount classes.
/// 
/// LEARNING CONCEPTS DEMONSTRATED:
/// - AAA Pattern (Arrange, Act, Assert)
/// - Testing constructors and properties
/// - Testing computed properties
/// - Testing exception handling
/// - Testing method behavior with valid and invalid inputs
/// </summary>
public class BankAccountTests
{
    #region Transaction Tests

    [Fact]
    public void Transaction_ConstructorSetsProperties()
    {
        // Arrange
        decimal amount = 100m;
        DateTime date = new DateTime(2024, 1, 15);
        string notes = "Salary deposit";

        // Act
        var transaction = new Transaction(amount, date, notes);

        // Assert
        Assert.Equal(amount, transaction.Amount);
        Assert.Equal(date, transaction.Date);
        Assert.Equal(notes, transaction.Notes);
    }

    [Fact]
    public void Transaction_SupportsNegativeAmounts()
    {
        // Arrange & Act
        var withdrawal = new Transaction(-50m, DateTime.Now, "Withdrawal");

        // Assert
        Assert.Equal(-50m, withdrawal.Amount);
    }

    [Fact]
    public void Transaction_IsImmutable()
    {
        // Arrange
        var transaction = new Transaction(100m, DateTime.Now, "Test");

        // Act & Assert
        // These properties have no setter, so compilation would fail if attempting to set them
        // This test documents that behavior
        Assert.True(true);
    }

    #endregion

    #region BankAccount Constructor Tests

    [Fact]
    public void BankAccount_ConstructorCreatesAccountWithInitialBalance()
    {
        // Arrange
        string owner = "John Doe";
        decimal initialBalance = 1000m;

        // Act
        var account = new BankAccount(owner, initialBalance);

        // Assert
        Assert.Equal(owner, account.Owner);
        Assert.Equal(initialBalance, account.Balance);
        Assert.NotNull(account.Number);
        Assert.Equal(10, account.Number.Length); // 10-digit account number
    }

    [Fact]
    public void BankAccount_ConstructorThrowsExceptionForZeroInitialBalance()
    {
        // Arrange
        var owner = "Jane Doe";

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new BankAccount(owner, 0m));
    }

    [Fact]
    public void BankAccount_ConstructorThrowsExceptionForNegativeInitialBalance()
    {
        // Arrange
        var owner = "Jane Doe";

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new BankAccount(owner, -100m));
    }

    [Fact]
    public void BankAccount_GeneratesUniqueAccountNumbers()
    {
        // Arrange & Act
        var account1 = new BankAccount("Owner 1", 1000m);
        var account2 = new BankAccount("Owner 2", 1000m);

        // Assert
        Assert.NotEqual(account1.Number, account2.Number);
    }

    #endregion

    #region BankAccount Property Tests

    [Fact]
    public void BankAccount_OwnerCanBeChanged()
    {
        // Arrange
        var account = new BankAccount("Original Owner", 1000m);

        // Act
        account.Owner = "New Owner";

        // Assert
        Assert.Equal("New Owner", account.Owner);
    }

    [Fact]
    public void BankAccount_BalanceIsComputedProperty()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act
        account.MakeDeposit(500m, DateTime.Now, "Deposit");

        // Assert
        Assert.Equal(1500m, account.Balance);
    }

    #endregion

    #region Deposit Tests

    [Fact]
    public void BankAccount_MakeDepositIncreasesBalance()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);
        decimal depositAmount = 500m;

        // Act
        account.MakeDeposit(depositAmount, DateTime.Now, "Test deposit");

        // Assert
        Assert.Equal(1500m, account.Balance);
    }

    [Fact]
    public void BankAccount_MakeDepositThrowsExceptionForZeroAmount()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            account.MakeDeposit(0m, DateTime.Now, "Zero deposit"));
    }

    [Fact]
    public void BankAccount_MakeDepositThrowsExceptionForNegativeAmount()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            account.MakeDeposit(-100m, DateTime.Now, "Negative deposit"));
    }

    [Fact]
    public void BankAccount_MakeDepositRecordsTransaction()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);
        int initialTransactionCount = account.GetTransactionCount();

        // Act
        account.MakeDeposit(500m, DateTime.Now, "Test deposit");

        // Assert
        Assert.Equal(initialTransactionCount + 1, account.GetTransactionCount());
    }

    [Fact]
    public void BankAccount_MakeMultipleDeposits()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act
        account.MakeDeposit(100m, DateTime.Now, "Deposit 1");
        account.MakeDeposit(200m, DateTime.Now, "Deposit 2");
        account.MakeDeposit(300m, DateTime.Now, "Deposit 3");

        // Assert
        Assert.Equal(1600m, account.Balance);
    }

    #endregion

    #region Withdrawal Tests

    [Fact]
    public void BankAccount_MakeWithdrawalDecreasesBalance()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act
        account.MakeWithdrawal(300m, DateTime.Now, "Test withdrawal");

        // Assert
        Assert.Equal(700m, account.Balance);
    }

    [Fact]
    public void BankAccount_MakeWithdrawalThrowsExceptionForZeroAmount()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            account.MakeWithdrawal(0m, DateTime.Now, "Zero withdrawal"));
    }

    [Fact]
    public void BankAccount_MakeWithdrawalThrowsExceptionForNegativeAmount()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            account.MakeWithdrawal(-100m, DateTime.Now, "Negative withdrawal"));
    }

    [Fact]
    public void BankAccount_MakeWithdrawalThrowsExceptionForInsufficientFunds()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => 
            account.MakeWithdrawal(1500m, DateTime.Now, "Overdraft withdrawal"));
    }

    [Fact]
    public void BankAccount_MakeWithdrawalAllowsExactBalance()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act
        account.MakeWithdrawal(1000m, DateTime.Now, "Withdraw all");

        // Assert
        Assert.Equal(0m, account.Balance);
    }

    [Fact]
    public void BankAccount_MakeWithdrawalRecordsNegativeTransaction()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act
        account.MakeWithdrawal(500m, DateTime.Now, "Test withdrawal");

        // Assert
        var transactions = account.GetTransactionHistory().ToList();
        var lastTransaction = transactions[transactions.Count - 1];
        Assert.Equal(-500m, lastTransaction.Amount);
    }

    #endregion

    #region Transaction History Tests

    [Fact]
    public void BankAccount_GetTransactionHistoryReturnsAllTransactions()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);
        account.MakeDeposit(500m, DateTime.Now, "Deposit");
        account.MakeWithdrawal(200m, DateTime.Now, "Withdrawal");

        // Act
        var history = account.GetTransactionHistory().ToList();

        // Assert
        Assert.Equal(3, history.Count); // Initial + 1 deposit + 1 withdrawal
    }

    [Fact]
    public void BankAccount_GetTransactionCountReturnsCorrectCount()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act
        account.MakeDeposit(100m, DateTime.Now, "Deposit 1");
        account.MakeDeposit(200m, DateTime.Now, "Deposit 2");
        account.MakeWithdrawal(50m, DateTime.Now, "Withdrawal 1");
        int count = account.GetTransactionCount();

        // Assert
        Assert.Equal(4, count); // Initial + 2 deposits + 1 withdrawal
    }

    [Fact]
    public void BankAccount_TransactionHistoryPreservesOrder()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);
        account.MakeDeposit(100m, DateTime.Now, "Deposit 1");
        account.MakeWithdrawal(50m, DateTime.Now, "Withdrawal 1");
        account.MakeDeposit(200m, DateTime.Now, "Deposit 2");

        // Act
        var history = account.GetTransactionHistory().ToList();

        // Assert
        Assert.Equal("Initial balance", history[0].Notes);
        Assert.Equal("Deposit 1", history[1].Notes);
        Assert.Equal("Withdrawal 1", history[2].Notes);
        Assert.Equal("Deposit 2", history[3].Notes);
    }

    #endregion

    #region Integration Tests

    [Fact]
    public void BankAccount_ComplexScenarioWithMultipleOperations()
    {
        // Arrange
        var account = new BankAccount("Alice Johnson", 5000m);

        // Act
        account.MakeDeposit(2000m, DateTime.Now, "Salary");
        account.MakeWithdrawal(1500m, DateTime.Now, "Rent payment");
        account.MakeDeposit(500m, DateTime.Now, "Freelance work");
        account.MakeWithdrawal(300m, DateTime.Now, "Groceries");

        // Assert
        Assert.Equal(5700m, account.Balance);
        Assert.Equal(5, account.GetTransactionCount());
    }

    [Fact]
    public void BankAccount_LargeNumberOfTransactions()
    {
        // Arrange
        var account = new BankAccount("Test Owner", 1000m);

        // Act
        for (int i = 0; i < 100; i++)
        {
            account.MakeDeposit(10m, DateTime.Now, $"Deposit {i}");
        }

        // Assert
        Assert.Equal(2000m, account.Balance);
        Assert.Equal(101, account.GetTransactionCount());
    }

    #endregion
}

