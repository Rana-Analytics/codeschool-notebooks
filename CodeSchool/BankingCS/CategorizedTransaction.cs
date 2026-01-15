namespace BankingCS;

/// <summary>
/// Enumeration to categorize different types of transactions.
/// Helps track spending and income by category (useful for accounting analysis).
/// 
/// LEARNING CONCEPTS:
/// - Enumerations (enum) for fixed sets of values
/// - Named constants with integer values
/// </summary>
public enum TransactionCategory
{
    // Income categories
    Salary = 1,
    Freelance = 2,
    Investment = 3,
    Refund = 4,

    // Expense categories
    Groceries = 10,
    Utilities = 11,
    Rent = 12,
    Entertainment = 13,
    Transportation = 14,
    Healthcare = 15,
    Insurance = 16,

    // General
    Transfer = 20,
    Fee = 21,
    Other = 99
}

/// <summary>
/// Represents a categorized transaction with additional accounting details.
/// Extends the basic Transaction concept to include transaction categorization.
/// 
/// LEARNING CONCEPTS:
/// - Inheritance (extending Transaction functionality)
/// - Constructor chaining and base class initialization
/// - Additional properties to track business logic
/// - Computed properties for financial analysis
/// 
/// STUDENT EXERCISE:
/// This class should inherit from Transaction and add the following:
/// 1. A Category property (TransactionCategory) that cannot be changed after creation
/// 2. A Constructor that accepts all Transaction parameters plus a category
/// 3. A Method to get the transaction category name as a string
/// </summary>
public class CategorizedTransaction : Transaction
{
    /// <summary>
    /// Gets the category of this transaction.
    /// This is immutable - set during construction and cannot be changed.
    /// </summary>
    public TransactionCategory Category { get; }

    /// <summary>
    /// Creates a new CategorizedTransaction with full accounting details.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Complete this constructor to:
    /// 1. Call the base Transaction constructor with amount, date, and note parameters
    /// 2. Set the Category property
    /// 3. Consider: What validation should be done? What exceptions might be appropriate?
    /// </summary>
    /// <param name="amount">The transaction amount (positive for deposits, negative for withdrawals).</param>
    /// <param name="date">The date and time the transaction occurred.</param>
    /// <param name="note">A descriptive note about the transaction.</param>
    /// <param name="category">The category classification for this transaction.</param>
    public CategorizedTransaction(decimal amount, DateTime date, string note, TransactionCategory category)
        : base(amount, date, note)
    {
        // TODO: Implement this constructor
        // Set the Category property
        throw new NotImplementedException("Student must implement this constructor");
    }

    /// <summary>
    /// Gets a human-readable name for the transaction category.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// This method should return the English name of the Category enum value.
    /// For example, TransactionCategory.Salary should return "Salary"
    /// 
    /// HINT: You can use the ToString() method on enums, but a better practice
    /// for accounting purposes is to use a switch expression or statement to return
    /// meaningful names, potentially with additional details.
    /// </summary>
    /// <returns>The category name as a string.</returns>
    public string GetCategoryName()
    {
        // TODO: Implement this method
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Determines if this transaction is an income (positive) or expense (negative).
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Return true if the amount is positive (income), false if negative (expense).
    /// </summary>
    /// <returns>True if this is income, false if expense.</returns>
    public bool IsIncome()
    {
        // TODO: Implement this method
        throw new NotImplementedException("Student must implement this method");
    }
}
