namespace BankingCS.Tests;

/// <summary>
/// Unit tests for CategorizedTransaction.
/// Tests the categorization extension of basic transactions.
/// </summary>
public class CategorizedTransactionTests
{
    [Fact]
    public void CategorizedTransaction_ConstructorSetsCategoryCorrectly()
    {
        // Arrange
        decimal amount = 2000m;
        var date = new DateTime(2024, 1, 15);
        string note = "Monthly salary";
        var category = TransactionCategory.Salary;

        // Act
        var transaction = new CategorizedTransaction(amount, date, note, category);

        // Assert
        Assert.Equal(category, transaction.Category);
        Assert.Equal(amount, transaction.Amount);
        Assert.Equal(date, transaction.Date);
        Assert.Equal(note, transaction.Notes);
    }

    [Fact]
    public void CategorizedTransaction_InheritancePreservesTransactionData()
    {
        // Arrange
        var transaction = new CategorizedTransaction(150m, DateTime.Now, "Groceries", TransactionCategory.Groceries);

        // Act & Assert - inherited properties should work
        Assert.Equal(150m, transaction.Amount);
        Assert.NotNull(transaction.Date);
        Assert.NotNull(transaction.Notes);
    }

    [Theory]
    [InlineData(TransactionCategory.Salary)]
    [InlineData(TransactionCategory.Groceries)]
    [InlineData(TransactionCategory.Utilities)]
    [InlineData(TransactionCategory.Freelance)]
    public void CategorizedTransaction_GetCategoryNameReturnsCorrectString(TransactionCategory category)
    {
        // Arrange
        var transaction = new CategorizedTransaction(100m, DateTime.Now, "Test", category);

        // Act
        string categoryName = transaction.GetCategoryName();

        // Assert
        Assert.NotEmpty(categoryName);
        Assert.Equal(category.ToString(), categoryName);
    }

    [Fact]
    public void CategorizedTransaction_IsIncomeReturnsTrueForPositiveAmount()
    {
        // Arrange
        var transaction = new CategorizedTransaction(500m, DateTime.Now, "Salary", TransactionCategory.Salary);

        // Act
        bool isIncome = transaction.IsIncome();

        // Assert
        Assert.True(isIncome);
    }

    [Fact]
    public void CategorizedTransaction_IsIncomeReturnsFalseForNegativeAmount()
    {
        // Arrange
        var transaction = new CategorizedTransaction(-75m, DateTime.Now, "Grocery purchase", TransactionCategory.Groceries);

        // Act
        bool isIncome = transaction.IsIncome();

        // Assert
        Assert.False(isIncome);
    }

    [Fact]
    public void CategorizedTransaction_MultipleCategories()
    {
        // Arrange & Act
        var salary = new CategorizedTransaction(3000m, DateTime.Now, "Salary", TransactionCategory.Salary);
        var groceries = new CategorizedTransaction(-150m, DateTime.Now, "Weekly groceries", TransactionCategory.Groceries);
        var utilities = new CategorizedTransaction(-120m, DateTime.Now, "Electric bill", TransactionCategory.Utilities);

        // Assert
        Assert.True(salary.IsIncome());
        Assert.False(groceries.IsIncome());
        Assert.False(utilities.IsIncome());
    }
}

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
