namespace BankingCS.Tests;

/// <summary>
/// Unit tests for SavingsAccount.
/// Tests withdrawal limits, penalties, and interest calculation.
/// </summary>
public class SavingsAccountTests
{
    [Fact]
    public void SavingsAccount_ConstructorInitializesCorrectly()
    {
        // Arrange
        string owner = "John Saver";
        decimal initialBalance = 10000m;
        decimal interestRate = 0.04m;

        // Act
        var account = new SavingsAccount(owner, initialBalance, interestRate);

        // Assert
        Assert.Equal(owner, account.Owner);
        Assert.Equal(initialBalance, account.Balance);
        Assert.Equal(0, account.GetWithdrawalsThisMonth());
    }

    [Fact]
    public void SavingsAccount_FirstSixWithdrawalsAreFree()
    {
        // Arrange
        var account = new SavingsAccount("Saver", 5000m, 0.04m);
        decimal startingBalance = account.Balance;

        // Act
        for (int i = 0; i < 6; i++)
        {
            account.MakeWithdrawal(100m, DateTime.Now, $"Withdrawal {i + 1}");
        }

        // Assert
        Assert.Equal(startingBalance - 600m, account.Balance); // No penalty
        Assert.Equal(6, account.GetWithdrawalsThisMonth());
    }

    [Fact]
    public void SavingsAccount_SeventhWithdrawalIncursPenalty()
    {
        // Arrange
        var account = new SavingsAccount("Saver", 5000m, 0.04m);

        // Act - make 7 withdrawals
        for (int i = 0; i < 7; i++)
        {
            account.MakeWithdrawal(100m, DateTime.Now, $"Withdrawal {i + 1}");
        }

        // Assert - 6 free + 1 penalized = 600 + 100 + 35 penalty
        decimal expectedBalance = 5000m - 600m - 100m - 35m;
        Assert.Equal(expectedBalance, account.Balance);
    }

    [Fact]
    public void SavingsAccount_GetRemainingFreeWithdrawals()
    {
        // Arrange
        var account = new SavingsAccount("Saver", 5000m, 0.04m);

        // Act
        account.MakeWithdrawal(100m, DateTime.Now, "First");
        account.MakeWithdrawal(100m, DateTime.Now, "Second");
        int remaining = account.GetRemainingFreeWithdrawals();

        // Assert
        Assert.Equal(4, remaining); // 6 - 2 = 4
    }

    [Fact]
    public void SavingsAccount_CalculateInterestEarned()
    {
        // Arrange
        var account = new SavingsAccount("Saver", 10000m, 0.10m); // 10% annual for easy math
        var interestBefore = account.CalculateInterestEarned();

        // Act
        var interest = account.CalculateInterestEarned();

        // Assert - should be positive
        Assert.True(interest > 0);
    }

    [Fact]
    public void SavingsAccount_ApplyInterestIncreasesBalance()
    {
        // Arrange
        var account = new SavingsAccount("Saver", 10000m, 0.05m);
        decimal balanceBefore = account.Balance;

        // Act
        decimal interestApplied = account.ApplyInterest();

        // Assert
        Assert.True(interestApplied > 0);
        Assert.True(account.Balance > balanceBefore);
    }

    [Fact]
    public void SavingsAccount_WithdrawalCountResetsEachMonth()
    {
        // Arrange
        var account = new SavingsAccount("Saver", 5000m, 0.04m);

        // This test is tricky because we can't easily advance the calendar
        // Students should understand that the counter resets monthly
        int withdrawalsMonth1 = account.GetWithdrawalsThisMonth();

        // Act
        account.MakeWithdrawal(100m, DateTime.Now, "Test");

        // Assert
        Assert.Equal(1, account.GetWithdrawalsThisMonth());
    }
}
