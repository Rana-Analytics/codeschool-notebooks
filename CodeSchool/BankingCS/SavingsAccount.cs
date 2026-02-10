namespace BankingCS;

/// <summary>
/// Represents a savings account with a focus on preserving and growing money.
/// Implements InterestBearingAccount with simple interest calculation.
/// 
/// LEARNING CONCEPTS:
/// - Concrete implementation of abstract class
/// - Simple interest calculation
/// - Override keyword for method specialization
/// - Tiered restrictions (e.g., limits on withdrawals, penalties)
/// - Business logic for account rules
/// 
/// STUDENT EXERCISE:
/// Implement a SavingsAccount that extends InterestBearingAccount.
/// A savings account emphasizes saving rather than spending, so it may have:
/// - A limit on withdrawals per month
/// - A penalty fee for exceeding the withdrawal limit
/// - Higher interest rates than checking accounts
/// </summary>
public class SavingsAccount : InterestBearingAccount
{
    /// <summary>
    /// The maximum number of withdrawals allowed per calendar month.
    /// After this limit, a penalty is charged.
    /// </summary>
    private const int MaxWithdrawalsPerMonth = 6;

    /// <summary>
    /// The fee charged for each withdrawal exceeding the monthly limit.
    /// </summary>
    private const decimal OverdraftWithdrawalPenalty = 35m;

    /// <summary>
    /// Tracks the number of withdrawals made in the current month.
    /// </summary>
    private int withdrawalsThisMonth;

    /// <summary>
    /// Tracks the month/year for which we're counting withdrawals.
    /// </summary>
    private DateTime withdrawalCountDate;

    /// <summary>
    /// Creates a new savings account.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Complete this constructor to:
    /// 1. Call the base InterestBearingAccount constructor with name, initialBalance, and annualInterestRate
    /// 2. Initialize withdrawalsThisMonth to 0
    /// 3. Initialize withdrawalCountDate to DateTime.Now
    /// 
    /// LEARNING: Constructor chaining through multiple levels of inheritance.
    /// </summary>
    /// <param name="name">The account owner's name.</param>
    /// <param name="initialBalance">The initial deposit amount.</param>
    /// <param name="annualInterestRate">The annual interest rate (e.g., 0.04 for savings).</param>
    public SavingsAccount(string name, decimal initialBalance, decimal annualInterestRate)
        : base(name, initialBalance, annualInterestRate)
    {
        // TODO: Implement this constructor
        // Initialize withdrawal tracking
        throw new NotImplementedException("Student must implement this constructor");
    }

    /// <summary>
    /// Overrides MakeWithdrawal to enforce monthly withdrawal limits.
    /// Demonstrates method override and business rule enforcement.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// This method should:
    /// 1. Check if the current month matches withdrawalCountDate's month/year
    ///    - If it's a new month, reset withdrawalsThisMonth to 0 and update the date
    /// 2. Check if withdrawalsThisMonth < MaxWithdrawalsPerMonth
    ///    - If yes, allow the withdrawal and increment the counter
    ///    - If no, apply a penalty fee (charge OverdraftWithdrawalPenalty) before allowing withdrawal
    /// 3. Call the base MakeWithdrawal method
    /// 
    /// LEARNING: The override keyword allows you to customize behavior while
    /// maintaining the base class contract. The new keyword calls base functionality.
    /// 
    /// HINT: Check if a new month has started using DateTime.Now.Month and Year
    /// </summary>
    public override void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        // TODO: Implement withdrawal limit tracking and penalty logic
        // Check if it's a new month - if so, reset the counter
        // Track withdrawal count
        // Apply penalty if needed
        // Call base.MakeWithdrawal()
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Calculates interest using simple interest formula.
    /// Savings accounts typically use daily simple interest.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// This method should:
    /// 1. Calculate days elapsed since LastInterestDate (use DateTime.Now)
    /// 2. Call the static CalculateSimpleInterest method with:
    ///    - Current Balance
    ///    - AnnualInterestRate
    ///    - Days elapsed
    /// 3. Return the calculated interest
    /// 
    /// LEARNING: This demonstrates calling static utility methods and
    /// polymorphism - different account types calculate interest differently.
    /// </summary>
    public override decimal CalculateInterestEarned()
    {
        // TODO: Implement simple interest calculation
        // Calculate days since LastInterestDate
        // Call CalculateSimpleInterest()
        // Return the result
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Gets the number of withdrawals made in the current month.
    /// Useful for account holders to track their usage against limits.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Consider: Should this reset the month counter if needed, similar to MakeWithdrawal?
    /// </summary>
    /// <returns>The count of withdrawals in the current month.</returns>
    public int GetWithdrawalsThisMonth()
    {
        // TODO: Implement this method
        // Consider resetting if it's a new month
        throw new NotImplementedException("Student must implement this method");
    }

    /// <summary>
    /// Gets the number of remaining free withdrawals for this month.
    /// 
    /// TODO: STUDENT IMPLEMENTATION
    /// Return MaxWithdrawalsPerMonth - GetWithdrawalsThisMonth()
    /// </summary>
    /// <returns>The number of withdrawals remaining before penalty fees apply.</returns>
    public int GetRemainingFreeWithdrawals()
    {
        // TODO: Implement this method
        throw new NotImplementedException("Student must implement this method");
    }
}
