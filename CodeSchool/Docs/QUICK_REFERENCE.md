# C# Quick Reference for BankingCS

A quick reference guide for C# concepts and patterns used in the BankingCS project.

## Properties

### Read-Only Property
```csharp
public decimal Amount { get; }  // Can only be set in constructor
```

### Read-Write Property
```csharp
public string Owner { get; set; }  // Can be get or set anytime
```

### Computed Property
```csharp
public decimal Balance
{
    get
    {
        decimal total = 0;
        foreach (var transaction in allTransactions)
            total += transaction.Amount;
        return total;
    }
}
```

### Init Property (C# 9+)
```csharp
public DateTime CreatedDate { get; init; }  // Can only set during initialization
```

## Access Modifiers

```csharp
public decimal Balance { get; }           // Anyone can access

private List<Transaction> transactions;   // Only this class

protected decimal AnnualInterestRate { get; }  // This class + derived classes

internal string BankCode { get; set; }    // Same assembly only
```

## Constructors & Inheritance

### Simple Constructor
```csharp
public BankAccount(string name, decimal initialBalance)
{
    Owner = name;
    Number = accountNumberSeed.ToString();
}
```

### Constructor with Validation
```csharp
public BankAccount(string name, decimal initialBalance)
{
    if (initialBalance <= 0)
        throw new ArgumentOutOfRangeException(nameof(initialBalance), "Must be positive");
    
    Owner = name;
}
```

### Constructor Chaining (Inheritance)
```csharp
// Child class calls parent constructor with base()
public SavingsAccount(string name, decimal initial, decimal rate)
    : base(name, initial, rate)  // Pass to parent
{
    withdrawalsThisMonth = 0;
}
```

## Methods

### Simple Method
```csharp
public void MakeDeposit(decimal amount, DateTime date, string note)
{
    var deposit = new Transaction(amount, date, note);
    allTransactions.Add(deposit);
}
```

### Method with Return Value
```csharp
public decimal GetAverageTransactionAmount()
{
    if (Transactions.Count == 0) return 0;
    return Transactions.Sum(t => t.Amount) / Transactions.Count;
}
```

### Abstract Method (must be implemented by derived class)
```csharp
public abstract decimal CalculateInterestEarned();
```

### Virtual Method (can be overridden)
```csharp
public virtual void ApplyFee(decimal amount)
{
    // Default implementation
}
```

### Override Method (replaces parent implementation)
```csharp
public override void MakeWithdrawal(decimal amount, DateTime date, string note)
{
    // Custom logic
    base.MakeWithdrawal(amount, date, note);  // Call parent if needed
}
```

### Static Method (doesn't need instance)
```csharp
public static decimal CalculateSimpleInterest(decimal principal, decimal rate, int days)
{
    return principal * rate * (days / 365m);
}

// Call without creating object
var interest = InterestBearingAccount.CalculateSimpleInterest(1000m, 0.05m, 30);
```

## Collections

### List Declaration and Use
```csharp
private List<Transaction> allTransactions = new List<Transaction>();

// Add items
allTransactions.Add(newTransaction);

// Access by index
var firstTransaction = allTransactions[0];

// Iterate
foreach (var transaction in allTransactions)
{
    Console.WriteLine(transaction.Amount);
}

// Get count
int count = allTransactions.Count;

// Get read-only copy
var readOnly = allTransactions.AsReadOnly();
```

### IEnumerable Interface
```csharp
public IEnumerable<Transaction> GetTransactionHistory()
{
    return allTransactions.AsReadOnly();  // Safe, read-only access
}
```

## LINQ (Language Integrated Query)

### Where - Filter Items
```csharp
// Get only deposits (positive amounts)
var deposits = transactions.Where(t => t.Amount > 0);

// Get transactions over $100
var largeTransactions = transactions.Where(t => Math.Abs(t.Amount) > 100);
```

### Sum - Add Up Values
```csharp
// Total of all deposits
decimal totalDeposits = transactions
    .Where(t => t.Amount > 0)
    .Sum(t => t.Amount);

// Total of all amounts (including negatives)
decimal netChange = transactions.Sum(t => t.Amount);
```

### Average - Calculate Mean
```csharp
decimal avgTransactionAmount = transactions.Count == 0 
    ? 0 
    : transactions.Average(t => Math.Abs(t.Amount));
```

### Count - Count Items
```csharp
int depositCount = transactions.Where(t => t.Amount > 0).Count();
```

### MaxBy - Find Maximum
```csharp
// Find transaction with largest absolute amount
var largestTransaction = transactions
    .OrderByDescending(t => Math.Abs(t.Amount))
    .FirstOrDefault();

// Or use MaxBy (C# 11+)
var largest = transactions.MaxBy(t => Math.Abs(t.Amount));
```

### OrderBy / OrderByDescending - Sort
```csharp
var sortedByAmount = transactions.OrderBy(t => t.Amount);
var sortedByDate = transactions.OrderByDescending(t => t.Date);
```

### ToList - Materialize Results
```csharp
// LINQ returns IEnumerable, convert to List for storage
List<Transaction> depositsOnly = transactions
    .Where(t => t.Amount > 0)
    .ToList();
```

### Select - Transform Items (advanced)
```csharp
// Get just the amounts
var amounts = transactions.Select(t => t.Amount);

// Get custom objects
var summaries = transactions.Select(t => new 
{
    t.Amount,
    t.Date,
    IsDeposit = t.Amount > 0
});
```

## Exception Handling

### Throwing Exceptions
```csharp
if (amount <= 0)
    throw new ArgumentOutOfRangeException(nameof(amount), "Must be positive");

if (Balance - amount < 0)
    throw new InvalidOperationException("Insufficient funds");
```

### Common Exception Types
```csharp
// Invalid method parameter
throw new ArgumentOutOfRangeException(nameof(amount));
throw new ArgumentNullException(nameof(name));
throw new ArgumentException("Invalid format", nameof(value));

// Invalid operation
throw new InvalidOperationException("Cannot withdraw - account frozen");
throw new NotSupportedException("Feature not available");

// Not implemented yet (for student code)
throw new NotImplementedException("Student must implement this");
```

### Try-Catch (if you need to catch errors)
```csharp
try
{
    account.MakeWithdrawal(amount, DateTime.Now, note);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Cannot withdraw: {ex.Message}");
}
```

## Static Members

### Static Field (shared across all instances)
```csharp
private static int accountNumberSeed = 1234567890;

// In constructor
Number = accountNumberSeed.ToString();
accountNumberSeed++;  // Changes for next instance
```

### Static Method (doesn't use instance data)
```csharp
public static decimal CalculateSimpleInterest(decimal principal, decimal rate, int days)
{
    return principal * rate * (days / 365m);
}

// Call without creating object
var interest = InterestBearingAccount.CalculateSimpleInterest(1000m, 0.05m, 30);
```

### Static Constant
```csharp
private static decimal MAX_WITHDRAWAL_PER_MONTH = 6;
private const decimal OVERDRAFT_FEE = 35m;
```

## DateTime Operations

### Creating DateTime
```csharp
var now = DateTime.Now;
var specific = new DateTime(2024, 1, 15);
var date = new DateTime(2024, 1, 15, 14, 30, 0);  // With time
```

### DateTime Arithmetic
```csharp
var tomorrow = DateTime.Now.AddDays(1);
var nextMonth = DateTime.Now.AddMonths(1);
var later = DateTime.Now.AddHours(2);

// Days between dates
int daysBetween = (DateTime.Now - lastDate).Days;
```

### DateTime Components
```csharp
int month = DateTime.Now.Month;        // 1-12
int year = DateTime.Now.Year;          // 2024
int day = DateTime.Now.Day;            // 1-31
int hour = DateTime.Now.Hour;          // 0-23
```

### DateTime Comparison
```csharp
if (date1 > date2)           // date1 is after date2
if (date1.Month == 1)        // Is January?
if (date1.Year == 2024)      // Is 2024?
if (date1.Month != lastMonth) // Different month?
```

## Type System

### Decimal (for money - ALWAYS use this)
```csharp
decimal amount = 100.50m;      // 'm' suffix for decimal literal
decimal calculated = 1000m * 0.05m;
```

### Nullable Types
```csharp
Transaction? maybeTransaction = null;

if (maybeTransaction != null)
{
    Console.WriteLine(maybeTransaction.Amount);
}

// Or use null coalescing
var trans = maybeTransaction ?? new Transaction(0, DateTime.Now, "");
```

### Enums
```csharp
public enum TransactionCategory
{
    Salary = 1,
    Groceries = 10,
    Utilities = 11
}

var category = TransactionCategory.Salary;
string categoryName = category.ToString();  // "Salary"

// Switch on enum
switch (category)
{
    case TransactionCategory.Salary:
        Console.WriteLine("Income");
        break;
    case TransactionCategory.Groceries:
        Console.WriteLine("Expense");
        break;
}
```

## String Formatting

### String Interpolation
```csharp
var name = "John";
var balance = 1500.50m;

// Basic interpolation
var text = $"Account for {name}: ${balance}";

// With formatting
var currency = $"Balance: {balance:C}";      // $1,500.50
var percent = $"Rate: {0.05:P}";             // 50.00%
var decimal2 = $"Amount: {balance:F2}";      // 1500.50
```

### String Building (multi-line)
```csharp
var statement = $@"Account Statement
Owner: {Owner}
Account: {Number}
Balance: {Balance:C}
Transactions: {GetTransactionCount()}";
```

## Testing Patterns

### AAA Pattern (Arrange-Act-Assert)
```csharp
[Fact]
public void BankAccount_BalanceIncreasesAfterDeposit()
{
    // Arrange
    var account = new BankAccount("Test", 1000m);
    decimal depositAmount = 500m;
    
    // Act
    account.MakeDeposit(depositAmount, DateTime.Now, "Test");
    
    // Assert
    Assert.Equal(1500m, account.Balance);
}
```

### Testing Exceptions
```csharp
[Fact]
public void BankAccount_ThrowsExceptionForNegativeDeposit()
{
    var account = new BankAccount("Test", 1000m);
    
    Assert.Throws<ArgumentOutOfRangeException>(() =>
        account.MakeDeposit(-100m, DateTime.Now, "Invalid")
    );
}
```

### Theory Tests (multiple test cases)
```csharp
[Theory]
[InlineData(100m)]
[InlineData(1000m)]
[InlineData(10000m)]
public void BankAccount_AcceptsAnyPositiveDeposit(decimal amount)
{
    var account = new BankAccount("Test", 0m);
    account.MakeDeposit(amount, DateTime.Now, "Test");
    Assert.Equal(amount, account.Balance);
}
```

## Common Patterns

### Validation at Start of Method
```csharp
public void MakeDeposit(decimal amount, DateTime date, string note)
{
    // Validate first
    if (amount <= 0)
        throw new ArgumentOutOfRangeException(nameof(amount), "Must be positive");
    
    // Then do work
    var deposit = new Transaction(amount, date, note);
    allTransactions.Add(deposit);
}
```

### Method with Multiple Return Paths
```csharp
public decimal GetTotalWithdrawals()
{
    decimal total = 0;
    foreach (var transaction in allTransactions)
    {
        if (transaction.Amount < 0)
            total += Math.Abs(transaction.Amount);
    }
    return total;
}
```

### Safe Nullable Return
```csharp
public Transaction? GetLargestTransaction()
{
    if (allTransactions.Count == 0)
        return null;
    
    return allTransactions.MaxBy(t => Math.Abs(t.Amount));
}

// Usage
var largest = account.GetLargestTransaction();
if (largest != null)
{
    Console.WriteLine(largest.Amount);
}
```

### Abstract Class Implementation
```csharp
public abstract class InterestBearingAccount : BankAccount
{
    // Abstract method - derived classes MUST implement
    public abstract decimal CalculateInterestEarned();
    
    // Concrete method - can use abstract methods
    public decimal ApplyInterest()
    {
        decimal interest = CalculateInterestEarned();
        if (interest > 0)
        {
            MakeDeposit(interest, DateTime.Now, "Interest");
        }
        return interest;
    }
}
```

## Helpful Math Methods

```csharp
decimal abs = Math.Abs(-100m);                    // 100
decimal max = Math.Max(100m, 200m);               // 200
decimal min = Math.Min(100m, 200m);               // 100
decimal rounded = Math.Round(100.556m, 2);        // 100.56
decimal ceiling = Math.Ceiling(100.1m);           // 101
```

## Common Debugging Patterns

```csharp
// Print variable value
Console.WriteLine($"Balance: {account.Balance}");

// Print collection contents
foreach (var transaction in transactions)
{
    Console.WriteLine($"{transaction.Date}: {transaction.Amount}");
}

// Check condition
if (amount > 1000)
    Console.WriteLine("Large amount detected");

// Count items
var count = transactions.Where(t => t.Amount > 0).Count();
Console.WriteLine($"Number of deposits: {count}");
```

---

For complete examples and context, see the BankingCS source code and Docs/BANKING_CURRICULUM.md.
