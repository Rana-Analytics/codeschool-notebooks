namespace BankingCS;

/// <summary>
/// Represents a single transaction (deposit or withdrawal) on a bank account.
/// 
/// LEARNING CONCEPTS:
/// - Properties with get-only accessors (immutable after construction)
/// - DateTime for tracking transaction timing
/// - Decimal for precise financial calculations
/// </summary>
public class Transaction
{
    /// <summary>
    /// Gets the transaction amount. Positive for deposits, negative for withdrawals.
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// Gets the date and time when the transaction occurred.
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// Gets descriptive notes about the transaction (e.g., "Salary deposit", "ATM withdrawal").
    /// </summary>
    public string Notes { get; }

    /// <summary>
    /// Creates a new Transaction instance.
    /// </summary>
    /// <param name="amount">The transaction amount (positive for deposits, negative for withdrawals).</param>
    /// <param name="date">The date and time the transaction occurred.</param>
    /// <param name="note">A descriptive note about the transaction.</param>
    public Transaction(decimal amount, DateTime date, string note)
    {
        Amount = amount;
        Date = date;
        Notes = note;
    }
}
