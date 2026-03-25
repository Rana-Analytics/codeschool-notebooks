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
/// 
/// SOLUTION NOTES:
/// - Calls the base Transaction constructor to initialize inherited transaction data.
/// - Stores the supplied category as an immutable property.
/// - Exposes helper methods for category display and income/expense classification.
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
    /// SOLUTION NOTES:
    /// - Uses constructor chaining to initialize the Transaction portion of the object.
    /// - Persists the category as a read-only property after construction.
    /// </summary>
    /// <param name="amount">The transaction amount (positive for deposits, negative for withdrawals).</param>
    /// <param name="date">The date and time the transaction occurred.</param>
    /// <param name="note">A descriptive note about the transaction.</param>
    /// <param name="category">The category classification for this transaction.</param>
    public CategorizedTransaction(decimal amount, DateTime date, string note, TransactionCategory category)
        : base(amount, date, note)
    {
        // Store the category assigned to this transaction.
        Category = category;
    }

    /// <summary>
    /// Gets a human-readable name for the transaction category.
    /// 
    /// SOLUTION NOTES:
    /// - Returns the enum member name as a display string.
    /// - Example: TransactionCategory.Salary -> "Salary"
    /// </summary>
    /// <returns>The category name as a string.</returns>
    public string GetCategoryName()
    {
        return Category.ToString();
    }

    /// <summary>
    /// Determines if this transaction is an income (positive) or expense (negative).
    /// 
    /// SOLUTION NOTES:
    /// - Positive amounts are treated as income.
    /// - Negative amounts are treated as expenses.
    /// </summary>
    /// <returns>True if this is income, false if expense.</returns>
    public bool IsIncome()
    {
        // Transaction inherits Amount from the base Transaction class.
        return Amount > 0;
    }
}