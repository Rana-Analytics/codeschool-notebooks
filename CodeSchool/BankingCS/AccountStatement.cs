namespace BankingCS;

/// <summary>
/// Represents a summary of an account's transactions over a specific period.
/// Used for generating account statements.
/// 
/// LEARNING CONCEPTS:
/// - Working with collections (filtering, summing)
/// - Date range calculations
/// - LINQ for querying collections (optional but recommended)
/// - Reporting and summary calculations
/// - Different numeric types (decimal for money, int for counts)
/// 
/// STUDENT EXERCISE:
/// Implement an AccountStatement class that summarizes account activity.
/// This class demonstrates how to analyze transaction data and extract meaningful information.
/// </summary>
public class AccountStatement
{
    /// <summary>
    /// Gets the account number this statement is for.
    /// </summary>
    public string AccountNumber { get; }

    /// <summary>
    /// Gets the owner of this account.
    /// </summary>
    public string AccountOwner { get; }

    /// <summary>
    /// Gets the start date of the statement period (inclusive).
    /// </summary>
    public DateTime StatementStartDate { get; }

    /// <summary>
    /// Gets the end date of the statement period (inclusive).
    /// </summary>
    public DateTime StatementEndDate { get; }

    /// <summary>
    /// Gets the balance at the beginning of the statement period.
    /// </summary>
    public decimal OpeningBalance { get; }

    /// <summary>
    /// Gets the balance at the end of the statement period.
    /// </summary>
    public decimal ClosingBalance { get; }

    /// <summary>
    /// Gets all transactions that occurred during the statement period.
    /// </summary>
    public IEnumerable<Transaction> Transactions { get; }

    /// <summary>
    /// Creates a new account statement for a given period.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Complete this constructor to:
    /// 1. Set AccountNumber, AccountOwner, StatementStartDate, StatementEndDate
    /// 2. Calculate OpeningBalance:
    ///    - This is the balance before any transactions in the period
    ///    - Sum all transactions before StatementStartDate
    ///    - You'll need the initial balance from the account, then subtract pre-period transactions
    /// 3. Filter transactions to include only those in the date range
    /// 4. Calculate ClosingBalance:
    ///    - This is the OpeningBalance plus all transactions in the period
    /// 
    /// LEARNING: This demonstrates:
    /// - Working with date comparisons
    /// - LINQ querying (Where, ToList, etc.)
    /// - Calculating balances at different points in time
    /// </summary>
    /// <param name="account">The BankAccount to create a statement for.</param>
    /// <param name="startDate">The beginning of the statement period.</param>
    /// <param name="endDate">The end of the statement period.</param>
    public AccountStatement(BankAccount account, DateTime startDate, DateTime endDate)
    {
        // TODO: Implement this constructor
        // Set properties for AccountNumber, AccountOwner, statement dates
        // Filter and store transactions in the period
        // Calculate opening and closing balances
        throw new NotImplementedException("Student must implement this constructor");
    }

    /// <summary>
    /// Calculates the total deposits during the statement period.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Sum all transactions with Amount > 0
    /// 
    /// HINT: Use LINQ's Where() and Sum() methods, or a loop
    /// </summary>
    /// <returns>The total amount deposited.</returns>
    public decimal GetTotalDeposits()
    {
        // TODO: Implement this method
        // Sum all transactions where Amount > 0
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Calculates the total withdrawals during the statement period.
    /// Returns the absolute value (positive number).
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Sum all transactions with Amount < 0, then return the absolute value
    /// 
    /// Example: If you have withdrawals of -50 and -30, return 80 (not -80)
    /// </summary>
    /// <returns>The total amount withdrawn (as a positive number).</returns>
    public decimal GetTotalWithdrawals()
    {
        // TODO: Implement this method
        // Sum all transactions where Amount < 0
        // Return the absolute value
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Gets the net change in balance during the statement period.
    /// This is simply ClosingBalance - OpeningBalance.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Calculate the difference between closing and opening balances.
    /// This will be positive if deposits > withdrawals, negative otherwise.
    /// </summary>
    /// <returns>The net change in balance.</returns>
    public decimal GetNetChange()
    {
        // TODO: Implement this method
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Gets the count of transactions during the statement period.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Return the count of transactions in the period.
    /// </summary>
    /// <returns>The number of transactions.</returns>
    public int GetTransactionCount()
    {
        // TODO: Implement this method
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Gets transactions of a specific type (deposits or withdrawals).
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Filter transactions to include only deposits (isDeposit = true) or withdrawals (isDeposit = false)
    /// 
    /// HINT: Check if Amount > 0 for deposits, Amount < 0 for withdrawals
    /// </summary>
    /// <param name="isDeposit">If true, return only deposits. If false, return only withdrawals.</param>
    /// <returns>A collection of transactions matching the criteria.</returns>
    public IEnumerable<Transaction> GetTransactionsByType(bool isDeposit)
    {
        // TODO: Implement this method
        // Use Where() to filter based on Amount > 0 or Amount < 0
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Calculates the average transaction amount during the period.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// If there are no transactions, return 0.
    /// Otherwise, return the sum of all amounts divided by the count.
    /// 
    /// LEARNING: This demonstrates:
    /// - Checking for empty collections (Count == 0)
    /// - Using LINQ's Average() method, or calculating manually
    /// - Handling edge cases
    /// </summary>
    /// <returns>The average transaction amount.</returns>
    public decimal GetAverageTransactionAmount()
    {
        // TODO: Implement this method
        // Handle empty transaction list
        // Calculate average of all transaction amounts
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Gets the largest single transaction (by absolute value) during the period.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Find the transaction with the maximum absolute amount.
    /// If no transactions, return null.
    /// 
    /// LEARNING: This demonstrates:
    /// - Working with nullable return types (Transaction?)
    /// - Handling empty collections
    /// - Using LINQ's MaxBy() or similar
    /// </summary>
    /// <returns>The largest transaction, or null if no transactions.</returns>
    public Transaction? GetLargestTransaction()
    {
        // TODO: Implement this method
        // Find transaction with maximum absolute value
        // Return null if no transactions
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Generates a formatted summary string of the statement.
    /// Useful for display or printing account statements.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Create a multi-line string showing:
    /// - Account Number
    /// - Owner Name
    /// - Period (Statement Start Date to End Date)
    /// - Opening Balance
    /// - Total Deposits
    /// - Total Withdrawals
    /// - Closing Balance
    /// - Net Change
    /// - Transaction Count
    /// 
    /// Format each monetary value with 2 decimal places using ToString("C") or similar.
    /// 
    /// LEARNING: This demonstrates string formatting and building
    /// complex output using string interpolation.
    /// </summary>
    /// <returns>A formatted statement summary.</returns>
    public string GetStatementSummary()
    {
        // TODO: Implement this method
        // Build a multi-line string with all statement details
        // Use string interpolation and formatting
        throw new NotImplementedException("Student must implement this method");
    }
}
