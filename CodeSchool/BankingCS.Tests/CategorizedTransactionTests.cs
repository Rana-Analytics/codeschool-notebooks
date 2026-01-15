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
