namespace BankingCS.Tests;

/// <summary>
/// Unit tests for CheckingAccount.
/// Tests monthly fees and overdraft protection.
/// </summary>
public class CheckingAccountTests
{
    [Fact]
    public void CheckingAccount_ConstructorInitializesCorrectly()
    {
        // Arrange
        string owner = "Jane Checker";
        decimal initialBalance = 5000m;

        // Act
        var account = new CheckingAccount(owner, initialBalance);

        // Assert
        Assert.Equal(owner, account.Owner);
        Assert.Equal(initialBalance, account.Balance);
        Assert.True(account.OverdraftProtectionEnabled);
    }

    [Fact]
    public void CheckingAccount_OverdraftProtectionAllowsNegativeBalance()
    {
        // Arrange
        var account = new CheckingAccount("Checker", 1000m);
        account.OverdraftProtectionEnabled = true;

        // Act
        account.MakeWithdrawal(1500m, DateTime.Now, "Overdraft withdrawal");

        // Assert
        Assert.True(account.Balance < 0);
    }

    [Fact]
    public void CheckingAccount_OverdraftProtectionChargesFee()
    {
        // Arrange
        var account = new CheckingAccount("Checker", 1000m);
        account.OverdraftProtectionEnabled = true;

        // Act
        account.MakeWithdrawal(1500m, DateTime.Now, "Overdraft withdrawal");

        // Assert - 1000 - 1500 - 35 fee = -535
        Assert.Equal(-535m, account.Balance);
    }

    [Fact]
    public void CheckingAccount_DisabledOverdraftPreventionThrowsException()
    {
        // Arrange
        var account = new CheckingAccount("Checker", 1000m);
        account.OverdraftProtectionEnabled = false;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            account.MakeWithdrawal(1500m, DateTime.Now, "Overdraft attempt"));
    }

    [Fact]
    public void CheckingAccount_IsFeeWaivedWhenBalanceHigh()
    {
        // Arrange
        var account = new CheckingAccount("Checker", 1000m);

        // Act
        bool isFeeWaived = account.IsFeeWaived();

        // Assert - balance is 1000, minimum is 500, so fee is waived
        Assert.True(isFeeWaived);
    }

    [Fact]
    public void CheckingAccount_IsFeeChargedWhenBalanceLow()
    {
        // Arrange
        var account = new CheckingAccount("Checker", 300m);

        // Act
        bool isFeeWaived = account.IsFeeWaived();

        // Assert - balance is 300, minimum is 500, so fee applies
        Assert.False(isFeeWaived);
    }

    [Fact]
    public void CheckingAccount_GetMonthlyFeeReturnsCorrectAmount()
    {
        // Arrange & Act
        var accountHighBalance = new CheckingAccount("Checker", 1000m);
        var accountLowBalance = new CheckingAccount("Checker", 300m);

        // Assert
        Assert.Equal(0m, accountHighBalance.GetMonthlyFee()); // Fee waived
        Assert.Equal(10m, accountLowBalance.GetMonthlyFee()); // Fee charged
    }

    [Fact]
    public void CheckingAccount_ApplyMonthlyMaintenanceFeeChargesWhenDue()
    {
        // Arrange
        var account = new CheckingAccount("Checker", 300m); // Balance < 500
        decimal balanceBefore = account.Balance;

        // Act
        decimal feeCharged = account.ApplyMonthlyMaintenanceFee();

        // Assert
        Assert.Equal(10m, feeCharged);
        Assert.Equal(balanceBefore - 10m, account.Balance);
    }

    [Fact]
    public void CheckingAccount_ApplyMonthlyMaintenanceFeeWaivedForHighBalance()
    {
        // Arrange
        var account = new CheckingAccount("Checker", 1000m); // Balance >= 500
        decimal balanceBefore = account.Balance;

        // Act
        decimal feeCharged = account.ApplyMonthlyMaintenanceFee();

        // Assert
        Assert.Equal(0m, feeCharged);
        Assert.Equal(balanceBefore, account.Balance); // No change
    }
}
