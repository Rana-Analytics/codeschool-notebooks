namespace BankingCS;

/// <summary>
/// Represents a checking account designed for frequent transactions.
/// Implements InterestBearingAccount with minimal interest (or none).
/// 
/// LEARNING CONCEPTS:
/// - Concrete implementation of abstract base class
/// - Monthly fee structure
/// - Transaction limits and fees
/// - Balance tiers (some checking accounts have different benefits at different balance levels)
/// - Overdraft protection
/// 
/// STUDENT EXERCISE:
/// Implement a CheckingAccount that extends InterestBearingAccount.
/// A checking account is designed for frequent transactions:
/// - May charge monthly maintenance fees
/// - May offer overdraft protection (with fees)
/// - Typically has low or zero interest
/// - Usually allows unlimited deposits and withdrawals (unlike savings)
/// </summary>
public class CheckingAccount : InterestBearingAccount
{
    /// <summary>
    /// The monthly maintenance fee charged to the account.
    /// Waived if certain conditions are met (e.g., minimum balance).
    /// </summary>
    private const decimal MonthlyMaintenanceFee = 10m;

    /// <summary>
    /// The minimum balance required to waive the monthly maintenance fee.
    /// </summary>
    private const decimal MinimumBalanceForFeeWaiver = 500m;

    /// <summary>
    /// Whether this checking account has overdraft protection enabled.
    /// If true, it allows negative balance but charges a fee.
    /// </summary>
    public bool OverdraftProtectionEnabled { get; set; }

    /// <summary>
    /// The fee charged when an overdraft occurs.
    /// </summary>
    private const decimal OverdraftFee = 35m;

    /// <summary>
    /// Tracks the last date the monthly maintenance fee was charged.
    /// </summary>
    private DateTime lastFeeDate;

    /// <summary>
    /// Creates a new checking account.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Complete this constructor to:
    /// 1. Call the base InterestBearingAccount constructor
    /// 2. Initialize OverdraftProtectionEnabled to true (common for checking accounts)
    /// 3. Initialize lastFeeDate to DateTime.Now
    /// 
    /// LEARNING: Most checking accounts include overdraft protection by default.
    /// </summary>
    /// <param name="name">The account owner's name.</param>
    /// <param name="initialBalance">The initial deposit amount.</param>
    /// <param name="annualInterestRate">The annual interest rate (typically 0 for checking).</param>
    public CheckingAccount(string name, decimal initialBalance, decimal annualInterestRate = 0m)
        : base(name, initialBalance, annualInterestRate)
    {
        // TODO: Implement this constructor
        // Initialize OverdraftProtectionEnabled and lastFeeDate
        throw new NotImplementedException("Student must implement this constructor");
    }

    /// <summary>
    /// Overrides MakeWithdrawal to support overdraft protection.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// This method should:
    /// 1. Check if the balance AFTER withdrawal would be negative
    /// 2. If it would be negative AND OverdraftProtectionEnabled is true:
    ///    - Allow the withdrawal
    ///    - Record an additional overdraft fee transaction
    /// 3. If it would be negative AND OverdraftProtectionEnabled is false:
    ///    - Throw an InvalidOperationException (same as base class)
    /// 4. Call the base MakeWithdrawal method
    /// 
    /// LEARNING: This demonstrates how different account types can have
    /// different rules for the same operation (withdrawal).
    /// </summary>
    public override void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        // TODO: Implement overdraft protection logic
        // Check if balance would go negative
        // If so and overdraft is enabled, allow it and charge a fee
        // Call base.MakeWithdrawal()
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Applies a monthly maintenance fee if conditions are met.
    /// This should be called periodically (perhaps monthly) to charge account fees.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// This method should:
    /// 1. Check if a month has passed since lastFeeDate
    /// 2. If balance < MinimumBalanceForFeeWaiver, charge MonthlyMaintenanceFee
    ///    - Create a withdrawal transaction for the fee
    ///    - Update lastFeeDate to DateTime.Now
    /// 3. Return the fee charged (or 0 if not charged)
    /// 
    /// LEARNING: This demonstrates conditional logic and date calculations.
    /// </summary>
    /// <returns>The amount of the fee charged (0 if waived).</returns>
    public decimal ApplyMonthlyMaintenanceFee()
    {
        // TODO: Implement monthly fee logic
        // Check if a month has passed
        // Check if balance qualifies for fee waiver
        // Charge fee if needed
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Calculates interest for a checking account.
    /// Most checking accounts have zero interest, but this allows for variation.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// This is typically zero for checking accounts, but some banks offer
    /// interest on checking accounts. This implementation should:
    /// 1. If AnnualInterestRate is 0, return 0 (no interest)
    /// 2. Otherwise, calculate simple interest like SavingsAccount
    /// 
    /// HINT: Check if AnnualInterestRate > 0 before doing the calculation.
    /// </summary>
    public override decimal CalculateInterestEarned()
    {
        // TODO: Implement interest calculation
        // Most checking accounts earn 0% interest
        // But allow for the possibility of some interest
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Checks if the monthly maintenance fee would be waived based on balance.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Return true if Balance >= MinimumBalanceForFeeWaiver
    /// </summary>
    /// <returns>True if the maintenance fee is waived, false otherwise.</returns>
    public bool IsFeeWaived()
    {
        // TODO: Implement this method
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Gets the monthly maintenance fee amount.
    /// Useful for showing account holders what they're paying.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Return MonthlyMaintenanceFee if not waived, 0 otherwise
    /// </summary>
    /// <returns>The monthly fee that would be charged.</returns>
    public decimal GetMonthlyFee()
    {
        // TODO: Implement this method
        throw new NotImplementedException("Student must implement this method");
    }
}
