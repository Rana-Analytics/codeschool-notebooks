using System.Collections.Generic;

namespace BankingCS;

/// <summary>
/// Represents a basic bank account that tracks deposits, withdrawals, and balance.
/// 
/// LEARNING CONCEPTS:
/// - Constructors and initialization
/// - Properties with getters and setters
/// - Computed properties (Balance calculated from transaction list)
/// - Static members (accountNumberSeed for unique account numbers)
/// - Collections (List<T>)
/// - Input validation with exceptions
/// - Methods with parameters
/// - Exception handling (ArgumentOutOfRangeException, InvalidOperationException)
/// </summary>
public class BankAccount
{
    /// <summary>
    /// Gets the unique account number. Auto-generated and read-only.
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// Gets or sets the name(s) of the account owner(s).
    /// </summary>
    public string Owner { get; set; }

    /// <summary>
    /// Gets the current account balance by summing all transaction amounts.
    /// This is a computed property - not stored, but calculated on-demand.
    /// </summary>
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var transaction in allTransactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }
    }

    /// <summary>
    /// Static field to generate unique 10-digit account numbers.
    /// Shared across all instances of BankAccount.
    /// </summary>
    private static int accountNumberSeed = 1234567890;

    /// <summary>
    /// Internal list storing all transactions for this account.
    /// </summary>
    private List<Transaction> allTransactions = new List<Transaction>();

    /// <summary>
    /// Creates a new bank account with an owner name and initial balance.
    /// </summary>
    /// <param name="name">The name of the account owner.</param>
    /// <param name="initialBalance">The initial deposit amount (must be positive).</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if initialBalance is not positive.</exception>
    public BankAccount(string name, decimal initialBalance)
    {
        Owner = name;
        Number = accountNumberSeed.ToString();
        accountNumberSeed++;

        // Make initial deposit to populate the account
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    /// <summary>
    /// Records a deposit transaction to the account.
    /// </summary>
    /// <param name="amount">The amount to deposit (must be positive).</param>
    /// <param name="date">The date of the deposit.</param>
    /// <param name="note">A description of the deposit.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if amount is not positive.</exception>
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }

        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    /// <summary>
    /// Records a withdrawal transaction from the account.
    /// </summary>
    /// <param name="amount">The amount to withdraw (must be positive).</param>
    /// <param name="date">The date of the withdrawal.</param>
    /// <param name="note">A description of the withdrawal.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if amount is not positive.</exception>
    /// <exception cref="InvalidOperationException">Thrown if withdrawal would result in negative balance.</exception>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }

        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }

        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
    }

    /// <summary>
    /// Returns a read-only copy of all transactions for this account.
    /// </summary>
    /// <returns>A copy of the transaction list.</returns>
    public IEnumerable<Transaction> GetTransactionHistory()
    {
        return allTransactions.AsReadOnly();
    }

    /// <summary>
    /// Gets the total number of transactions on this account.
    /// </summary>
    /// <returns>The count of transactions.</returns>
    public int GetTransactionCount()
    {
        return allTransactions.Count;
    }
}
