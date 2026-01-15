# BankingCS - Interactive C# Learning Project

A comprehensive, hands-on C# learning project designed for junior developers transitioning into software development. This project uses a banking domain that's familiar to developers with accounting backgrounds.

## Project Structure

### Core Project: `BankingCS/`
Contains the actual C# implementation with both completed and framework classes.

#### Completed Classes (Reference Implementation)
- **`Transaction.cs`**: Represents a single transaction (deposit/withdrawal)
- **`BankAccount.cs`**: Basic checking account with deposits, withdrawals, and balance tracking

Students should study these classes to understand:
- How properties work (read-only vs read/write)
- How constructors initialize objects
- Exception handling for validation
- Collections (List<T>) for storing data

#### Framework Classes (Student Assignments)
- **`CategorizedTransaction.cs`**: Extends Transaction with categorization
  - *Concepts*: Inheritance, Enums, Constructor chaining
  
- **`InterestBearingAccount.cs`**: Abstract base class for interest-earning accounts
  - *Concepts*: Abstract classes, Abstract methods, Static utilities, Template Method pattern
  
- **`SavingsAccount.cs`**: Savings account with withdrawal limits and penalties
  - *Concepts*: Method overriding, Business logic, State tracking
  
- **`CheckingAccount.cs`**: Checking account with overdraft protection and monthly fees
  - *Concepts*: Method overriding, Feature flags, Balance-based logic
  
- **`AccountStatement.cs`**: Generates account summaries and reports
  - *Concepts*: LINQ, Collection filtering, Date range calculations, Summary statistics

### Test Project: `BankingCS.Tests/`
Comprehensive unit tests validating both the foundation and student implementation.

- **`BankAccountTests.cs`**: Tests for Transaction and BankAccount (40+ tests)
- **`CategorizedTransactionTests.cs`**: Tests for CategorizedTransaction (7 tests)
- **`InterestBearingAccountTests.cs`**: Tests for InterestBearingAccount (5 tests)
- **`SavingsAccountTests.cs`**: Tests for SavingsAccount (7 tests)
- **`CheckingAccountTests.cs`**: Tests for CheckingAccount (8 tests)
- **`AccountStatementTests.cs`**: Tests for AccountStatement (10+ tests)

## Getting Started

### Prerequisites
- .NET 8.0+ SDK (specified in `global.json`)
- Visual Studio Code with C# extension
- Basic understanding of C# syntax

### Running the Tests

From the terminal inside VS Code run the following commands:
(Ctrl+Shirt+P then type "Terminal: Create New Terminal" to open a fresh one)

```bash
cd CodeSchool
dotnet test
```

### Expected Output

Initially, you should see:
- ✓ All BankAccount/Transaction tests passing (~25 tests)
- ✗ Framework tests failing with `NotImplementedException`

Open the [Test log](../CodeSchool/BankingCS.Tests/bin/Debug/net8.0/TestResults/BankingCS.Tests_net8.0_x64.log) to see specifics on failures.

After implementing framework classes:
- ✓ All tests passing (~66 tests)

## Learning Path

### Phase 1: Foundation (Study Existing Code)
**Duration**: 2-3 hours

1. Open `BankAccount.cs` and `Transaction.cs`
2. Read all XML comments carefully
3. Understand:
   - Why properties are immutable in Transaction
   - How validation prevents invalid states
   - How static members work (accountNumberSeed)
4. Run the tests: `dotnet test`
5. Trace through test cases to understand expected behavior

**Key Questions to Answer:**
- Why is Amount in Transaction read-only?
- How does the Balance property work without a backing field?
- What happens if you try to withdraw $2000 from a $1000 account?

### Phase 2: Categorization
**Duration**: 4-6 hours

1. Open `CategorizedTransaction.cs`
2. Read the TransactionCategory enum
3. Implement the three methods:
   - Constructor (call base() and set Category)
   - GetCategoryName() (return enum name)
   - IsIncome() (check if amount > 0)
4. Run tests: `dotnet test --filter "CategorizedTransaction"`
5. All CategorizedTransaction tests should pass

**Skills Practiced:**
- Inheritance and the `base` keyword
- Enums as type-safe named constants
- Method implementation from specifications

### Phase 3: Abstract Classes
**Duration**: 6-8 hours

1. Open `InterestBearingAccount.cs`
2. Understand abstract classes and why they're useful
3. Implement:
   - Protected constructor (call base, set fields)
   - Static utility method `CalculateSimpleInterest()`
   - Validation method `IsValidInterestRate()`
   - `ApplyInterest()` method (not abstract, concrete)
4. Note: `CalculateInterestEarned()` is abstract - derived classes implement it
5. Run tests: `dotnet test --filter "InterestBearing"` (will have some failures - that's OK)

**Skills Practiced:**
- Abstract base classes and contracts
- Static utility methods
- Template Method pattern
- Protected members in inheritance

### Phase 4: Savings Account
**Duration**: 8-10 hours

1. Open `SavingsAccount.cs`
2. Implement:
   - Constructor with withdrawal tracking
   - Override `MakeWithdrawal()` to enforce monthly limits
   - Implement `CalculateInterestEarned()` using simple interest
   - Helper methods for tracking
3. Key challenge: Monthly withdrawal limit resets
4. Run tests: `dotnet test --filter "SavingsAccount"`
5. Debug carefully - trace through withdrawal logic

**Skills Practiced:**
- Method overriding and polymorphism
- Business rule enforcement
- Date calculations and month comparisons
- State tracking across method calls

**Common Issues:**
- Forgetting to reset withdrawal counter monthly
- Confusing when to charge penalty fees
- Date comparison logic (comparing months)

### Phase 5: Checking Account
**Duration**: 8-10 hours

1. Open `CheckingAccount.cs`
2. Implement:
   - Constructor with feature flags
   - Override `MakeWithdrawal()` for overdraft protection
   - `ApplyMonthlyMaintenanceFee()` with balance tier logic
   - `CalculateInterestEarned()` (mostly zero)
   - Helper methods for fee waiver logic
3. Key challenge: Allowing negative balance while enforcing rules
4. Run tests: `dotnet test --filter "CheckingAccount"`

**Skills Practiced:**
- Alternative implementations (different from SavingsAccount)
- Feature toggles and runtime customization
- Tiered fees based on balance levels
- Conditional logic in method overrides

### Phase 6: Account Statements
**Duration**: 10-12 hours

1. Open `AccountStatement.cs`
2. This is the most complex class - lots of LINQ queries
3. Implement:
   - Constructor with date range filtering
   - `GetTotalDeposits()` and `GetTotalWithdrawals()`
   - `GetAverageTransactionAmount()` with edge case handling
   - `GetLargestTransaction()` returning nullable
   - `GetTransactionsByType()` with filtering
   - `GetStatementSummary()` for formatted output
4. Run tests: `dotnet test --filter "AccountStatement"`
5. This is challenging - take time to understand LINQ methods

**Skills Practiced:**
- LINQ queries (Where, Sum, Average, MaxBy)
- Collection filtering and aggregation
- Nullable reference types
- Date range calculations
- String formatting and interpolation

**LINQ Methods You'll Need:**
- `Where(x => condition)` - filter items
- `Sum()` - add up values
- `Average()` - calculate mean
- `MaxBy(x => x.Amount)` - find maximum
- `ToList()` - materialize as list
- `Count()` - get count of items

## Testing Strategy

### Running All Tests
```bash
dotnet test
```

### Running Tests for Specific Class
```bash
dotnet test --filter "SavingsAccount"
dotnet test --filter "CategorizedTransaction"
dotnet test --filter "AccountStatement"
dotnet test --filter "CheckingAccount"
dotnet test --filter "InterestBearingAccount"
```

### Running Tests Verbosely
```bash
dotnet test --logger "console;verbosity=detailed"
```

### Understanding Test Output
```
PASS  CategorizedTransaction_ConstructorSetsCategoryCorrectly
FAIL  CategorizedTransaction_GetCategoryNameReturnsCorrectString
       Expected: "Salary"
       Actual: NotImplementedException
```

This tells you:
1. Which test failed
2. What assertion failed
3. Expected vs actual values

## Key Concepts Reference

### Object-Oriented Programming
- **Classes**: Blueprints for objects (BankAccount)
- **Objects**: Instances of classes (specific account)
- **Properties**: Get/set access to data
- **Methods**: Functions that operate on data
- **Inheritance**: Child classes extend parent (SavingsAccount extends InterestBearingAccount)
- **Polymorphism**: Same method, different implementations
- **Encapsulation**: Hide internals, expose interface

### Collections
- **List<T>**: Ordered, mutable collection of items
- **IEnumerable<T>**: Read-only interface for iteration
- **LINQ**: Queries on collections (Where, Select, Sum, etc.)

### Exceptions
- **ArgumentOutOfRangeException**: Invalid method parameter
- **InvalidOperationException**: Invalid state for operation
- **NotImplementedException**: Placeholder for student code

### Properties and Fields
```csharp
// Read-only property (no setter)
public decimal Amount { get; }

// Read/write property
public string Owner { get; set; }

// Computed property (calculates value)
public decimal Balance { get { return CalculateBalance(); } }

// Private field (internal only)
private List<Transaction> allTransactions = new();

// Static field (shared across all instances)
private static int accountNumberSeed = 1234567890;
```

### Access Modifiers
- `public`: Anyone can access
- `private`: Only this class
- `protected`: This class and derived classes
- `internal`: This assembly only

## Debugging Tips

### When Tests Fail

1. **Read the error message carefully**
   - It tells you exactly what's wrong
   - Check expected vs actual values

2. **Use Console.WriteLine() for debugging**
   ```csharp
   public decimal CalculateInterestEarned()
   {
       int daysElapsed = (DateTime.Now - LastInterestDate).Days;
       Console.WriteLine($"Days elapsed: {daysElapsed}");
       decimal interest = CalculateSimpleInterest(Balance, AnnualInterestRate, daysElapsed);
       Console.WriteLine($"Calculated interest: {interest}");
       return interest;
   }
   ```

3. **Trace through logic manually**
   - Especially for complex scenarios (overdraft with fees, etc.)
   - Draw diagrams if it helps

4. **Check edge cases**
   - Empty lists
   - Null values
   - Boundary conditions (withdrawal exactly at limit)

5. **Compare with working example**
   - Look at how BankAccount.MakeWithdrawal() works
   - SavingsAccount should be similar but with additional logic

## Common Errors & Solutions

### NotImplementedException
**Problem**: Unimplemented method throws this exception
```
System.NotImplementedException: Student must implement this method
```
**Solution**: Replace the `throw` statement with actual implementation

### NullReferenceException
**Problem**: Accessing property/method on null object
```
System.NullReferenceException: Object reference not set to an instance of an object
```
**Common in**: 
- Not initializing collections
- Nullable types (Transaction?)
**Solution**: 
- Check constructor initialization
- Add null checks before use

### InvalidOperationException
**Problem**: Operation not allowed in current state
**Common in**: 
- Withdrawal without enough funds
- Overdraft protection disabled
**Solution**: Verify your condition logic matches test expectations

### Assertion Failures
**Problem**: Expected value doesn't match actual
```
Assert.Equal(1500m, account.Balance)
  Expected: 1500
  Actual:   1535
```
**Solution**: 
- Calculate expected value manually
- Check for missed fee additions
- Verify transaction amounts

### Month Reset Not Working
**Problem**: Withdrawal counter doesn't reset monthly
**Solution**: 
- Check if you're comparing `DateTime.Now.Month` and `Year`
- Print debug values: `Console.WriteLine(DateTime.Now.Month)`
- Ensure you update the stored date

## Project Files

### Source Code
```
BankingCS/
├── Transaction.cs              # Completed - study this
├── BankAccount.cs              # Completed - study this
├── CategorizedTransaction.cs   # Implement (easy)
├── InterestBearingAccount.cs   # Implement (medium)
├── SavingsAccount.cs           # Implement (medium-hard)
├── CheckingAccount.cs          # Implement (medium-hard)
├── AccountStatement.cs         # Implement (hard)
└── BankingCS.csproj
```

### Tests
```
BankingCS.Tests/
├── UnitTest1.cs                      # BankAccount/Transaction tests
├── CategorizedTransactionTests.cs    # CategorizedTransaction tests
├── InterestBearingAccountTests.cs    # InterestBearingAccount tests
├── SavingsAccountTests.cs            # SavingsAccount tests
├── CheckingAccountTests.cs           # CheckingAccount tests
├── AccountStatementTests.cs          # AccountStatement tests
├── BankingCS.Tests.csproj
└── xunit.runner.json
```

### Documentation
```
CodeSchool/
├── README.md                         # This file
├── Docs/                             # Documentation folder
│   ├── BANKING_CURRICULUM.md         # Complete curriculum guide
│   ├── FILE_GUIDE.md                 # File index and reading order
│   ├── QUICK_REFERENCE.md            # C# syntax reference
│   ├── INSTRUCTOR_GUIDE.md           # Teaching guide
│   ├── IMPLEMENTATION_SUMMARY.md     # Implementation details
│   ├── DELIVERY_SUMMARY.md           # Project delivery overview
│   └── INDEX.md                      # Navigation hub
└── CodeSchool.sln                    # Solution file
```

## Success Criteria

Your implementation is complete when:

1. ✓ All 66+ unit tests pass
2. ✓ No compilation errors or warnings
3. ✓ All methods work with the examples in tests
4. ✓ Edge cases are handled properly
5. ✓ Code is readable with good variable names

## Next Steps After Completion

### Review Your Code
- Does it follow the C# naming conventions?
- Are methods focused (single responsibility)?
- Are there any code smells (duplicated logic, etc.)?

### Extend the Project
- Add a `MoneyMarketAccount` class with tiered interest rates
- Implement `TransferBetweenAccounts()` method
- Add `AccountFrozen` property to prevent transactions
- Implement `PrintStatement()` for console output
- Add a `ReversalTransaction` for corrections

### Learn More
- Study the design patterns used (Template Method, Strategy)
- Understand SOLID principles and how they apply
- Explore async/await for long-running operations
- Learn about persistence (saving to database)

## Troubleshooting

### Tests Won't Run
```bash
# Make sure you're in the right directory
cd CodeSchool

# Restore NuGet packages
dotnet restore

# Run tests
dotnet test
```

### Compilation Errors
- Check that all classes are in the correct namespace (BankingCS)
- Verify method signatures match the interface (parameters and return types)
- Look for typos in class/method names

### Tests Still Failing After Implementation
- Read the test code to understand what's expected
- Print debug values to trace execution
- Compare your logic with the completed BankAccount class

## Getting Help

### Understanding Requirements
- Read the XML comments in the framework class
- Look at the corresponding test to see expected behavior
- Check BANKING_CURRICULUM.md for conceptual explanation

### Debugging Issues
- Enable verbose test output: `dotnet test --logger "console;verbosity=detailed"`
- Add Console.WriteLine() statements to trace execution
- Use visual debugger: Set breakpoints and step through code

### Conceptual Questions
- Review BANKING_CURRICULUM.md for learning objectives
- Check Key Concepts Reference section above
- Search Microsoft Learn for specific topics

## Resources

### Official C# Documentation
- [C# Fundamentals](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/)
- [LINQ Queries](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
- [Inheritance](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance/)

### XUnit Testing Framework
- [XUnit Documentation](https://xunit.net/)
- [Assert Methods](https://github.com/xunit/xunit/wiki/api/)

### Banking Domain Knowledge
- Learn about [Regulation D](https://www.federalreserve.gov/monetarypolicy/reserve-requirements.htm) (savings account withdrawal limits)
- Understand [Overdraft Protection](https://www.consumerfinance.gov/about-us/blog/what-overdraft-protection/)
- Study [Interest Calculations](https://en.wikipedia.org/wiki/Simple_interest)

## Summary

This project provides a complete learning path for junior developers:

1. **Study** existing, well-documented code
2. **Implement** progressively complex features
3. **Test** your work with comprehensive unit tests
4. **Understand** real-world banking concepts
5. **Apply** OOP principles and C# features

Good luck! 🚀
