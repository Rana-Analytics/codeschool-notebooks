namespace BankingCS;

/// <summary>
/// Represents an account that earns or pays interest based on the balance.
/// This introduces the concept of recurring calculations and financial growth.
/// 
/// LEARNING CONCEPTS:
/// - Abstract classes (inheritance without full implementation)
/// - Abstract methods and properties
/// - Virtual methods for customization
/// - Polymorphism (different account types, same interface)
/// - Interest calculation and compounding
/// - Static utility methods for financial calculations
/// 
/// STUDENT EXERCISE:
/// Complete this abstract base class that extends BankAccount functionality.
/// This class defines the contract for interest-bearing accounts but leaves
/// specific interest calculation to derived classes.
/// </summary>
public abstract class InterestBearingAccount : BankAccount
{
    /// <summary>
    /// The annual interest rate as a decimal (e.g., 0.05 for 5% APR).
    /// </summary>
    protected decimal AnnualInterestRate { get; }

    /// <summary>
    /// Gets or sets the date when interest was last calculated and applied.
    /// Used to ensure interest is not calculated multiple times for the same period.
    /// </summary>
    public DateTime LastInterestDate { get; protected set; }

    /// <summary>
    /// Creates a new interest-bearing account.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Complete this constructor to:
    /// 1. Call the base BankAccount constructor with name and initialBalance
    /// 2. Set the AnnualInterestRate property
    /// 3. Initialize LastInterestDate to the current date
    /// 
    /// LEARNING: This demonstrates constructor chaining in inheritance.
    /// </summary>
    /// <param name="name">The account owner's name.</param>
    /// <param name="initialBalance">The initial deposit amount.</param>
    /// <param name="annualInterestRate">The annual interest rate (e.g., 0.05 for 5%).</param>
    protected InterestBearingAccount(string name, decimal initialBalance, decimal annualInterestRate)
        : base(name, initialBalance)
    {
        // TODO: Implement this constructor
        // Set AnnualInterestRate and initialize LastInterestDate
        throw new NotImplementedException("Student must implement this constructor");
    }

    /// <summary>
    /// Calculates the interest earned for a given period based on the current balance.
    /// This method demonstrates polymorphism - different account types calculate interest differently.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// This is an abstract method, meaning derived classes MUST implement it.
    /// The basic formula is: InterestEarned = Balance * AnnualInterestRate * (DaysElapsed / 365)
    /// 
    /// Consider these variations:
    /// - Simple Interest: Uses the formula above
    /// - Compound Interest: Compounds at various intervals (daily, monthly, etc.)
    /// - Tiered Interest: Different rates for different balance levels
    /// </summary>
    /// <returns>The interest amount earned.</returns>
    public abstract decimal CalculateInterestEarned();

    /// <summary>
    /// Applies the calculated interest to the account as a deposit.
    /// This is the "action" method that makes the abstract calculation concrete.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// This method should:
    /// 1. Call CalculateInterestEarned() to get the interest amount
    /// 2. If interest > 0, create a deposit transaction for the interest
    /// 3. Update LastInterestDate to today
    /// 4. Return the amount of interest applied
    /// 
    /// LEARNING: This demonstrates the Template Method pattern - the overall
    /// structure is defined here, but specific calculation comes from subclasses.
    /// </summary>
    /// <returns>The amount of interest actually applied to the account.</returns>
    public decimal ApplyInterest()
    {
        // TODO: Implement this method
        // Call CalculateInterestEarned()
        // Create a deposit for the interest (if > 0)
        // Update LastInterestDate
        // Return the interest amount
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// A static utility method to calculate simple interest.
    /// Demonstrates static methods for shared functionality across all instances.
    /// 
    /// LEARNING CONCEPTS:
    /// - Static methods don't require an instance
    /// - Useful for utility/helper calculations
    /// - All parameters must be passed in (no access to instance fields)
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Complete this formula: Interest = Principal × AnnualRate × (DaysElapsed / 365)
    /// </summary>
    /// <param name="principal">The starting balance.</param>
    /// <param name="annualRate">The annual interest rate.</param>
    /// <param name="daysElapsed">The number of days elapsed since last calculation.</param>
    /// <returns>The calculated interest.</returns>
    public static decimal CalculateSimpleInterest(decimal principal, decimal annualRate, int daysElapsed)
    {
        // TODO: Implement the simple interest formula
        // Interest = Principal × AnnualRate × (DaysElapsed / 365)
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Validates that an interest rate is within reasonable bounds.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Return true if the rate is:
    /// - Greater than or equal to 0 (no negative interest for accounts)
    /// - Less than or equal to 1.0 (no rates above 100%)
    /// - Reasonable for a bank (typically 0 to 0.15, i.e., 0% to 15%)
    /// 
    /// LEARNING: This demonstrates validation logic and boolean return types.
    /// </summary>
    /// <param name="rate">The interest rate to validate.</param>
    /// <returns>True if the rate is valid, false otherwise.</returns>
    protected static bool IsValidInterestRate(decimal rate)
    {
        // TODO: Implement validation logic
        throw new NotImplementedException("Student must implement this method");
    }
}
