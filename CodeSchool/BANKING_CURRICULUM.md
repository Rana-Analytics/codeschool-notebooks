# BankingCS: C# Learning Curriculum

## Overview

This comprehensive C# learning project uses a banking theme to teach fundamental programming concepts and object-oriented design principles. The curriculum is structured around a real-world domain (banking) that resonates with junior developers who have accounting backgrounds.

The project includes:
- **Completed Classes**: `Transaction` and `BankAccount` that students learn from
- **Framework Classes**: Student assignments with detailed comments but no implementation
- **Unit Tests**: Comprehensive tests that validate student implementations

## Curriculum Structure

### Foundation Level: Transaction & BankAccount
**Focus**: Basic OOP, properties, constructors, validation, exceptions

#### Learning Objectives:
- Understand classes and objects in C#
- Learn about properties (get-only, get/set)
- Understand constructors and initialization
- Learn exception handling (throwing and catching)
- Understand immutability (read-only properties)
- Learn about collections (List<T>)
- Understand static members and their shared state

#### Key Concepts Covered:

1. **Properties and Encapsulation**
   - Read-only properties (`public decimal Amount { get; }`)
   - Read-write properties (`public string Owner { get; set; }`)
   - Computed properties (Balance calculated from transactions)
   
2. **Constructors**
   - Required initialization parameters
   - Setting field values
   - Calling other methods from constructor (MakeDeposit)
   
3. **Validation & Exceptions**
   - `ArgumentOutOfRangeException` for invalid amounts
   - `InvalidOperationException` for insufficient funds
   - Checking preconditions before operations
   
4. **Collections**
   - `List<T>` for storing multiple items
   - Iterating with `foreach`
   - Read-only access via `IEnumerable<T>`
   
5. **Static Members**
   - `accountNumberSeed` shared across all instances
   - Incrementing unique values
   - Class-level state vs instance-level state

#### Assessment:
- Students should understand why properties are immutable (Transaction)
- Understand why validation happens before modifying state
- Recognize the difference between Balance (computed) vs stored fields
- Comprehend how static fields work in generating unique account numbers

---

### Intermediate Level: Categorization & Basic Inheritance
**Focus**: Inheritance, enum types, extension, polymorphism basics

#### Class: CategorizedTransaction
**Concepts**: Inheritance, Enums, Constructor chaining, Method overriding

**Learning Objectives:**
- Understand inheritance and the `base` keyword
- Learn enum types for fixed sets of values
- Extend existing classes with new functionality
- Understand constructor chaining in inheritance
- Practice working with inherited properties

**Assignment Tasks:**
1. Implement the constructor that calls `base()` and sets Category
2. Implement `GetCategoryName()` using enum ToString or switch expression
3. Implement `IsIncome()` to distinguish deposits from withdrawals

**Key Learning:**
- Inheritance allows extending existing classes without modifying them
- The `base` keyword accesses parent class functionality
- Enums provide type-safe named constants
- Child classes automatically have access to parent properties

**Accounting Context:**
Junior developers will understand that categorizing transactions is crucial for accounting analysis. This is similar to how QuickBooks or other accounting software tags transactions for reporting.

---

### Advanced Level 1: Abstract Classes & Polymorphism
**Focus**: Abstract base classes, interface contracts, polymorphic behavior

#### Class: InterestBearingAccount (Abstract)
**Concepts**: Abstract classes, Abstract methods, Static utility methods, Template Method Pattern

**Learning Objectives:**
- Understand abstract classes and why they're useful
- Learn abstract methods and their role in defining contracts
- Understand polymorphism in practice
- Learn the Template Method pattern
- Practice static utility methods
- Understand protected members and inheritance visibility

**Assignment Tasks:**
1. Implement the constructor with proper base() call
2. Implement abstract method `CalculateInterestEarned()` (left for derived classes)
3. Implement `ApplyInterest()` that calls abstract method and deposits interest
4. Implement static utility `CalculateSimpleInterest()` for shared calculations
5. Implement `IsValidInterestRate()` for validation

**Key Learning:**
- Abstract classes cannot be instantiated directly
- Abstract methods force derived classes to implement specific behavior
- Static methods are utility functions shared across all instances
- The Template Method pattern: structure is defined in base, specifics in derived classes
- `protected` keyword allows sharing between parent and child classes

**Accounting Context:**
Interest calculation is fundamental to banking. Different account types calculate interest differently (daily compound, monthly, etc.). The abstract class enforces that all interest-bearing accounts must implement interest calculation.

---

### Advanced Level 2: Specialized Account Types
**Focus**: Concrete implementation, method overriding, business logic, conditional logic

#### Class: SavingsAccount (Extends InterestBearingAccount)
**Concepts**: Method overriding, Business rule enforcement, State tracking, Date calculations

**Learning Objectives:**
- Implement concrete versions of abstract methods
- Enforce business rules (withdrawal limits, penalties)
- Understand method override and the `new` keyword
- Track state across multiple calls
- Understand when to increment/reset counters
- Date arithmetic and month comparisons

**Assignment Tasks:**
1. Implement constructor with withdrawal tracking initialization
2. Override `MakeWithdrawal()` to enforce monthly limits and assess penalties
3. Implement `CalculateInterestEarned()` using simple interest formula
4. Track withdrawal count per month (reset on new month)
5. Implement helper methods for withdrawal tracking

**Key Learning:**
- The `override` keyword replaces parent method behavior
- Business logic (withdrawal limits) can be enforced in derived classes
- Date comparisons help reset monthly tracking
- Penalties are additional transactions that affect balance

**Accounting Context:**
Savings accounts commonly have withdrawal limits (formerly Regulation D). This teaches students about real-world banking constraints and how they're enforced programmatically.

**Common Misconceptions to Address:**
- Students might forget to reset the withdrawal counter monthly
- Penalty fees are additional transactions, not just balance reductions
- Need to check month changes, not just count withdrawals

---

#### Class: CheckingAccount (Extends InterestBearingAccount)
**Concepts**: Method overriding, Conditional withdrawal behavior, Feature toggling, Balance tiers

**Learning Objectives:**
- Override methods to provide alternative behavior
- Implement feature flags (OverdraftProtectionEnabled)
- Understand tiered fees based on balance levels
- Implement monthly recurring operations
- Practice conditional logic in method overrides

**Assignment Tasks:**
1. Implement constructor with overdraft protection enabled by default
2. Override `MakeWithdrawal()` to allow negative balance if protection is on
3. Implement `ApplyMonthlyMaintenanceFee()` with balance-based waiver logic
4. Implement `CalculateInterestEarned()` (mostly zero for checking)
5. Implement balance tier logic for fee waiver

**Key Learning:**
- Different account types have different rules for the same operations
- Feature toggles (OverdraftProtectionEnabled) allow runtime customization
- Monthly recurring operations need date tracking
- Balance tiers are common in banking (different rates at different balances)

**Accounting Context:**
Overdraft protection and monthly fees are standard checking account features. Students will recognize these from their own bank accounts, making the learning relevant.

**Common Misconceptions:**
- Overdraft fee only charged if protection is enabled and balance goes negative
- Monthly fee waiver is based on balance, not number of transactions
- Fee application requires date tracking to prevent double-charging

---

### Advanced Level 3: Data Analysis & Reporting
**Focus**: Collection manipulation, LINQ queries, Period calculations, Summary statistics

#### Class: AccountStatement
**Concepts**: LINQ, Collection filtering, Date range calculations, Summary statistics

**Learning Objectives:**
- Use LINQ to filter and aggregate data
- Calculate multiple financial metrics from transaction history
- Handle edge cases (no transactions, nullable returns)
- Summarize complex data in human-readable format
- Understand period-based reporting

**Assignment Tasks:**
1. Implement constructor that filters transactions by date range
2. Calculate opening balance (balance before period)
3. Calculate closing balance (current balance at period end)
4. Implement `GetTotalDeposits()` and `GetTotalWithdrawals()`
5. Implement `GetNetChange()` and `GetAverageTransactionAmount()`
6. Implement `GetLargestTransaction()` with nullable return handling
7. Implement `GetTransactionsByType()` with filtering
8. Implement `GetStatementSummary()` for formatted output

**Key Learning:**
- LINQ provides powerful query capabilities on collections
- `Where()`, `Sum()`, `Average()`, `MaxBy()` are essential collection methods
- Date ranges help isolate data for specific periods
- Nullable return types (`Transaction?`) handle "no result" scenarios
- String interpolation formats output for display

**Data Types & Incompatibilities:**
- Mixing `int` (count) with `decimal` (amount) requires understanding numeric hierarchy
- `Math.Abs()` for absolute values
- Decimal precision important for financial calculations

**Accounting Context:**
Bank statements are the primary way account holders understand their finances. Teaching students to build a statement class gives them insight into how banks generate this important reporting tool.

**Common Misconceptions:**
- Opening balance is NOT the starting balance of the account, it's the balance before the period starts
- Largest transaction is by absolute value, not just the highest number
- Transaction counts must include appropriate filters

---

## Implementation Sequence

### Phase 1: Foundation (Week 1)
- Review Transaction and BankAccount implementation (DONE - students review only)
- Pass all BankAccountTests
- Understand properties, constructors, exceptions

### Phase 2: Categorization (Week 2)
- Implement CategorizedTransaction
- Pass CategorizedTransactionTests
- Understand inheritance and enums

### Phase 3: Interest Bearing (Week 3)
- Implement InterestBearingAccount (abstract)
- Understand abstract classes and static methods
- Note: Tests may not fully pass until Phase 4

### Phase 4: Savings Account (Week 4)
- Implement SavingsAccount
- Pass SavingsAccountTests
- Understand method override and business rule enforcement

### Phase 5: Checking Account (Week 4-5)
- Implement CheckingAccount
- Pass CheckingAccountTests
- Understand alternative implementations

### Phase 6: Statements (Week 5-6)
- Implement AccountStatement
- Pass AccountStatementTests
- Understand LINQ and reporting

---

## Key C# Concepts Covered

### Object-Oriented Programming
- **Classes & Objects**: Every class represents a real banking entity
- **Properties**: Multiple forms (read-only, read/write, computed)
- **Constructors**: Initialization with validation
- **Inheritance**: Extending base classes (InterestBearingAccount → SavingsAccount)
- **Polymorphism**: Different implementations of same method (CalculateInterestEarned)
- **Encapsulation**: Private fields, public properties

### Access Modifiers
- `public`: Account number, balance (external access needed)
- `private`: Transaction list (internal only)
- `protected`: Interest rate (for inheritance)
- Field vs property distinction

### Collections
- `List<T>`: Generic, ordered, mutable
- `IEnumerable<T>`: Read-only iteration interface
- `.AsReadOnly()`: Return safe copies
- LINQ: `Where()`, `Sum()`, `Average()`, `MaxBy()`

### Exception Handling
- `throw` keywords for validation errors
- `ArgumentOutOfRangeException`: Invalid parameters
- `InvalidOperationException`: Invalid state
- When to throw vs when to return null/default

### Static Members
- Class-level data (accountNumberSeed)
- Utility methods (CalculateSimpleInterest)
- Shared across all instances

### Type System
- `decimal` for financial calculations (not `double` or `float`)
- `DateTime` for transaction timing
- `bool` for flags and conditions
- `enum` for categorization
- Nullable types (`Transaction?`)

### Advanced Patterns
- Template Method Pattern (ApplyInterest structure)
- Strategy Pattern (polymorphic interest calculation)
- Feature Flags (OverdraftProtectionEnabled)

---

## Common Student Errors & Debugging

### Error 1: NotImplementedException
**Issue**: Student hasn't implemented method yet
**Solution**: Check the TODO comments for implementation guidance

### Error 2: NullReferenceException
**Issue**: Trying to use an object that hasn't been initialized
**Common in**: AccountStatement when not properly initialized, nullable types
**Solution**: Check constructor initialization, use null checks

### Error 3: ArgumentOutOfRangeException from Test
**Issue**: Validation logic rejecting valid inputs
**Common in**: Constructor validation, withdrawal logic
**Debug**: Check if validation conditions are correct (< vs <=)

### Error 4: Test Expecting Wrong Balance
**Issue**: Incorrect transaction amount calculation
**Common in**: Overdraft fees, interest calculation, multiple transactions
**Debug**: Manually calculate expected result, trace through logic

### Error 5: Month Counter Not Resetting
**Issue**: DateTime.Now.Month comparison not working as expected
**Common in**: SavingsAccount withdrawal limits
**Debug**: Print current month/year, compare with stored date

### Error 6: LINQ Filtering Wrong Transactions
**Issue**: Where clause has wrong condition
**Common in**: AccountStatement, GetTransactionsByType
**Debug**: Test with simple data, verify Amount > 0 vs < 0

---

## Real-World Connections

### For Accounting Background Developers

1. **Chart of Accounts**: Transaction categories map to GL accounts
2. **Debit/Credit**: Positive (deposit) vs negative (withdrawal) amounts
3. **Trial Balance**: Account statement closing balance should match ledger
4. **Reconciliation**: Account statement helps verify transactions
5. **Regulatory Compliance**: Withdrawal limits (Reg D), overdraft rules

### For Career Growth

1. **Banking Systems**: These concepts are used in real banking software
2. **Financial Reporting**: Statement generation is core banking function
3. **Risk Management**: Overdraft protection and fee policies manage risk
4. **Customer Experience**: Different account types serve different needs

---

## Extension Exercises (Optional)

### For Advanced Students

1. **Interest Compounding**: Implement compound interest (daily, monthly)
2. **Multiple Currencies**: Handle multi-currency accounts
3. **Transaction Reversal**: Implement correction/reversal logic
4. **Account Freezing**: Add status property to prevent operations
5. **Audit Trail**: Track who made changes and when
6. **Data Persistence**: Save/load accounts from database
7. **Scheduled Transfers**: Implement recurring payments
8. **Alerts & Notifications**: Alert when balance is low
9. **Multi-Account Family**: Linked accounts, transfers between them
10. **Reporting**: Generate various financial reports (by category, by period)

---

## Assessment Rubric

### Code Quality (25%)
- Proper naming conventions
- Comments and documentation
- Clean, readable code
- No code smells

### Functionality (50%)
- All unit tests pass
- Edge cases handled
- Proper exception handling
- Correct calculations

### Understanding (25%)
- Can explain concepts used
- Can debug issues independently
- Understands inheritance hierarchy
- Recognizes design patterns

---

## Resources for Students

### C# Documentation
- [Microsoft Learn: C# Fundamentals](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [C# Language Guide](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/)

### Object-Oriented Design
- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)
- [Design Patterns](https://refactoring.guru/design-patterns)

### Financial Concepts
- Simple vs Compound Interest
- Account fees and their purpose
- Banking regulations (Regulation D, etc.)

---

## Instructor Notes

### Pacing
- Week 1: Foundation (review Transaction/BankAccount)
- Weeks 2-3: Intermediate (CategorizedTransaction, InterestBearingAccount)
- Weeks 4-5: Advanced Account Types
- Week 6: Reporting and Summary

### Engagement Strategies
- Use real bank examples (student accounts, savings, checking)
- Connect to accounting concepts they already know
- Show how concepts appear in production banking software
- Discuss recent banking innovations (digital wallets, etc.)

### Common Teaching Points
- Emphasize that exceptions are not "bad" - they're intentional
- Show how inheritance reduces code duplication
- Explain why interface contracts (abstract methods) are powerful
- Discuss how financial institutions scale these patterns

### Demo Ideas
1. Show actual bank statement and map to AccountStatement properties
2. Demo how withdrawal limits work in real savings accounts
3. Show overdraft protection in action (using test data)
4. Calculate interest manually to show formula correctness
5. Generate a statement from mock data and discuss components

---

## Conclusion

The BankingCS project provides junior developers with:
- A familiar real-world domain (banking)
- Progressive complexity from basic to advanced OOP
- Practical unit tests to validate learning
- Concepts directly applicable to production systems
- Hands-on experience with C# fundamentals

By completing this curriculum, students will have concrete understanding of:
- Object-oriented design
- Class hierarchies and polymorphism
- Data analysis and reporting
- Test-driven development
- Professional coding practices

The accounting background will help these students appreciate the business logic and regulatory constraints that make banking software complex and important.
