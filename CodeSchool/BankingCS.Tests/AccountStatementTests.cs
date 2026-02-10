namespace BankingCS.Tests;

/// <summary>
/// Unit tests for AccountStatement.
/// Tests period summaries, filtering, and calculations.
/// </summary>
public class AccountStatementTests
{
    [Fact]
    public void AccountStatement_ContainsOnlyTransactionsInPeriod()
    {
        // Arrange
        var account = new BankAccount("Statement Test", 1000m);
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        account.MakeDeposit(500m, startDate.AddDays(5), "Deposit 1");
        account.MakeDeposit(300m, startDate.AddDays(15), "Deposit 2");
        account.MakeDeposit(200m, endDate.AddDays(5), "Deposit outside period");

        // Act
        var statement = new AccountStatement(account, startDate, endDate);

        // Assert - should have initial + 2 deposits in period, not the third
        Assert.Equal(3, statement.GetTransactionCount());
    }

    [Fact]
    public void AccountStatement_CalculatesTotalDepositsCorrectly()
    {
        // Arrange
        var account = new BankAccount("Statement Test", 1000m);
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        account.MakeDeposit(500m, startDate.AddDays(5), "Deposit 1");
        account.MakeDeposit(300m, startDate.AddDays(15), "Deposit 2");

        // Act
        var statement = new AccountStatement(account, startDate, endDate);
        decimal totalDeposits = statement.GetTotalDeposits();

        // Assert - 1000 initial + 500 + 300 = 1800
        Assert.Equal(1800m, totalDeposits);
    }

    [Fact]
    public void AccountStatement_CalculatesTotalWithdrawalsCorrectly()
    {
        // Arrange
        var account = new BankAccount("Statement Test", 5000m);
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        account.MakeWithdrawal(500m, startDate.AddDays(5), "Withdrawal 1");
        account.MakeWithdrawal(300m, startDate.AddDays(15), "Withdrawal 2");

        // Act
        var statement = new AccountStatement(account, startDate, endDate);
        decimal totalWithdrawals = statement.GetTotalWithdrawals();

        // Assert - 500 + 300 = 800 (positive value)
        Assert.Equal(800m, totalWithdrawals);
    }

    [Fact]
    public void AccountStatement_CalculatesOpeningBalance()
    {
        // Arrange
        var account = new BankAccount("Statement Test", 1000m);
        var startDate = new DateTime(2024, 1, 15); // After initial deposit

        // Act
        var statement = new AccountStatement(account, startDate, startDate.AddDays(14));

        // Assert - opening balance should be the initial 1000
        Assert.Equal(1000m, statement.OpeningBalance);
    }

    [Fact]
    public void AccountStatement_CalculatesClosingBalance()
    {
        // Arrange
        var account = new BankAccount("Statement Test", 1000m);
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        account.MakeDeposit(500m, startDate.AddDays(5), "Deposit");
        account.MakeWithdrawal(200m, startDate.AddDays(15), "Withdrawal");

        // Act
        var statement = new AccountStatement(account, startDate, endDate);

        // Assert - closing balance should be current balance
        Assert.Equal(account.Balance, statement.ClosingBalance);
    }

    [Fact]
    public void AccountStatement_GetNetChangeCalculatesCorrectly()
    {
        // Arrange
        var account = new BankAccount("Statement Test", 1000m);
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        account.MakeDeposit(500m, startDate.AddDays(5), "Deposit");
        account.MakeWithdrawal(200m, startDate.AddDays(15), "Withdrawal");

        // Act
        var statement = new AccountStatement(account, startDate, endDate);
        decimal netChange = statement.GetNetChange();

        // Assert - net change should be 500 - 200 = 300
        Assert.Equal(300m, netChange);
    }

    [Fact]
    public void AccountStatement_GetAverageTransactionAmount()
    {
        // Arrange
        var account = new BankAccount("Statement Test", 1000m);
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        account.MakeDeposit(500m, startDate.AddDays(5), "Deposit 1");
        account.MakeDeposit(300m, startDate.AddDays(15), "Deposit 2");

        // Act
        var statement = new AccountStatement(account, startDate, endDate);
        decimal average = statement.GetAverageTransactionAmount();

        // Assert - (1000 + 500 + 300) / 3 = 600
        Assert.Equal(600m, average);
    }

    [Fact]
    public void AccountStatement_GetLargestTransaction()
    {
        // Arrange
        var account = new BankAccount("Statement Test", 1000m);
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        account.MakeDeposit(500m, startDate.AddDays(5), "Deposit 1");
        account.MakeDeposit(300m, startDate.AddDays(15), "Deposit 2");
        account.MakeWithdrawal(800m, startDate.AddDays(20), "Large withdrawal");

        // Act
        var statement = new AccountStatement(account, startDate, endDate);
        var largestTransaction = statement.GetLargestTransaction();

        // Assert - largest by absolute value is -800
        Assert.NotNull(largestTransaction);
        Assert.Equal(-800m, largestTransaction.Amount);
    }

    [Fact]
    public void AccountStatement_GetTransactionsByTypeFiltersCorrectly()
    {
        // Arrange
        var account = new BankAccount("Statement Test", 1000m);
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        account.MakeDeposit(500m, startDate.AddDays(5), "Deposit 1");
        account.MakeDeposit(300m, startDate.AddDays(15), "Deposit 2");
        account.MakeWithdrawal(200m, startDate.AddDays(20), "Withdrawal");

        // Act
        var statement = new AccountStatement(account, startDate, endDate);
        var deposits = statement.GetTransactionsByType(true).ToList();
        var withdrawals = statement.GetTransactionsByType(false).ToList();

        // Assert
        Assert.Equal(3, deposits.Count); // Initial + 2 deposits
        Assert.Equal(1, withdrawals.Count); // 1 withdrawal
    }

    [Fact]
    public void AccountStatement_GetStatementSummaryFormatsCorrectly()
    {
        // Arrange
        var account = new BankAccount("John Doe", 1000m);
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        account.MakeDeposit(500m, startDate.AddDays(5), "Deposit");

        // Act
        var statement = new AccountStatement(account, startDate, endDate);
        string summary = statement.GetStatementSummary();

        // Assert - summary should contain key information
        Assert.Contains(account.Number, summary);
        Assert.Contains("John Doe", summary);
        Assert.Contains(startDate.ToString(), summary);
        Assert.NotEmpty(summary);
    }

    [Fact]
    public void AccountStatement_EmptyStatementPeriod()
    {
        // Arrange
        var account = new BankAccount("Statement Test", 1000m);
        var startDate = new DateTime(2024, 1, 15);
        var endDate = new DateTime(2024, 1, 14); // End before start - edge case

        // Act
        var statement = new AccountStatement(account, startDate, endDate);

        // Assert - should handle gracefully
        Assert.Equal(0, statement.GetTransactionCount());
    }
}
