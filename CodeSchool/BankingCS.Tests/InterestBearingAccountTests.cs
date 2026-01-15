namespace BankingCS.Tests;

/// <summary>
/// Unit tests for InterestBearingAccount.
/// Tests abstract base class functionality and interest calculation utilities.
/// Note: InterestBearingAccount is abstract, so these tests primarily verify
/// the concrete methods and static utilities it provides.
/// </summary>
public class InterestBearingAccountTests
{
    [Fact]
    public void InterestBearingAccount_CalculateSimpleInterestStaticMethod()
    {
        // Arrange
        decimal principal = 10000m;
        decimal rate = 0.05m; // 5% annual
        int days = 365;

        // Act
        decimal interest = InterestBearingAccount.CalculateSimpleInterest(principal, rate, days);

        // Assert - 10000 * 0.05 * 1 = 500
        Assert.Equal(500m, interest);
    }

    [Fact]
    public void InterestBearingAccount_CalculateSimpleInterestPartialYear()
    {
        // Arrange
        decimal principal = 10000m;
        decimal rate = 0.05m;
        int days = 180; // Half year

        // Act
        decimal interest = InterestBearingAccount.CalculateSimpleInterest(principal, rate, days);

        // Assert - 10000 * 0.05 * 0.5 = 250
        Assert.Equal(250m, interest);
    }

    [Fact]
    public void InterestBearingAccount_IsValidInterestRate_ValidRate()
    {
        // Arrange
        decimal validRate = 0.05m;

        // Act
        bool isValid = InterestBearingAccount.IsValidInterestRate(validRate);

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void InterestBearingAccount_IsValidInterestRate_NegativeRate()
    {
        // Arrange
        decimal negativeRate = -0.05m;

        // Act
        bool isValid = InterestBearingAccount.IsValidInterestRate(negativeRate);

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void InterestBearingAccount_IsValidInterestRate_HighRate()
    {
        // Arrange
        decimal highRate = 1.5m; // 150% - unrealistic

        // Act
        bool isValid = InterestBearingAccount.IsValidInterestRate(highRate);

        // Assert
        Assert.False(isValid);
    }
}
