# Instructor Guide: Using BankingCS for C# Teaching

A complete guide for instructors on implementing the BankingCS project with junior developers.

## Overview

BankingCS is a comprehensive, hands-on C# learning project designed to deepen junior developers' understanding of object-oriented programming. The project bridges the gap between C# 101 (notebooks) and production-ready code.

**Target Students**: Junior developers with accounting backgrounds  
**Duration**: 6 weeks (2-3 hours/week for coding, 1-2 hours/week for review)  
**Prerequisites**: Completion of C# 101 modules (especially modules 13-15)

## Before You Start

### Setup
1. Ensure .NET 8.0+ is installed
2. Students have VS Code with C# extension
3. Clone/download the csharp-notebooks repository
4. Review the project structure yourself first

### Understanding the Project
1. Read IMPLEMENTATION_SUMMARY.md for complete overview
2. Study BANKING_CURRICULUM.md for learning objectives
3. Run tests locally: `cd CodeSchool && dotnet test`
4. Review the source code in BankingCS/ and BankingCS.Tests/

## Curriculum Integration

### Where This Fits
```
C# 101 Modules (Notebooks)
       ↓
BankingCS Foundation (Review Transaction & BankAccount)
       ↓
BankingCS Assignments (Implement 5 framework classes)
       ↓
More Advanced C# Topics (SOLID, Design Patterns, Async)
```

### Week-by-Week Schedule

#### Week 1: Foundation (2-3 hours)
**Goals**: Review basics, understand project structure, pass foundation tests

**Activities**:
- Day 1: Project orientation
  - Have students clone repo
  - Open CodeSchool/ folder in VS Code
  - Run `dotnet test` to see test output
  - Read README.md Getting Started section
  
- Day 2-3: Study existing code
  - Read Transaction.cs line by line
  - Read BankAccount.cs and understand design
  - Study BankAccountTests to see how they work
  - Discuss: Why are properties immutable? What happens if you try to set Amount?
  - Run tests: `dotnet test --filter "BankAccount"`
  - Should see 40+ tests passing

**Assessment**: Students understand Transaction and BankAccount design

**Discussions**:
- "Why is `Amount` read-only in Transaction?"
- "How does the static `accountNumberSeed` work?"
- "Why does BankAccount have a computed `Balance` property?"
- "When should you throw exceptions vs return values?"

---

#### Week 2: Categorization (3-4 hours)
**Goals**: Implement CategorizedTransaction, understand inheritance

**Pre-Class**:
- Students read BANKING_CURRICULUM.md "Categorization" section
- Students review QUICK_REFERENCE.md inheritance section

**Class Activities**:
- Day 1: Inheritance discussion
  - What is inheritance? (Code reuse, "is-a" relationship)
  - What is the `base` keyword?
  - How does constructor chaining work?
  - Demo: Show how BankAccount extends InterestBearingAccount (preview)

- Day 2: CategorizedTransaction implementation
  - Walk through the TransactionCategory enum
  - Have students implement the constructor
  - Have students implement GetCategoryName()
  - Have students implement IsIncome()
  - Hint: Use enum.ToString() or switch expression

- Day 3: Review and test
  - Run: `dotnet test --filter "CategorizedTransaction"`
  - All 7 tests should pass
  - Discuss: What was easy? What was confusing?

**Key Teaching Points**:
- Child class calls parent with `base()`
- Enums provide type safety
- Inheritance allows extending without modifying original

**Common Errors**:
- Forgetting to call `base()` - compiler error
- Not understanding how to access parent properties
- Confusing enum values with names

**Extension**: 
- Have students add another category
- Have students create a SubcategoryTransaction

---

#### Week 3: Abstract Classes (4-5 hours)
**Goals**: Implement InterestBearingAccount, understand abstract classes

**Pre-Class**:
- Students read BANKING_CURRICULUM.md "Interest Bearing" section
- Students watch/read about abstract classes

**Class Activities**:
- Day 1: Abstract concepts discussion
  - Why can't you create an instance of abstract class?
  - What is an abstract method?
  - How is this different from inheritance?
  - Pattern: Template Method (structure in base, specifics in derived)

- Day 2: Static methods and utilities
  - Review CalculateSimpleInterest formula
  - Implement static method
  - Note: No `this` in static methods
  - Discuss: When should you use static?

- Day 3: Constructor implementation
  - Call base constructor
  - Set protected fields
  - Initialize dates

- Day 4: ApplyInterest implementation
  - Call abstract CalculateInterestEarned()
  - Create deposit transaction if interest > 0
  - Update LastInterestDate
  - Note: This is Template Method pattern

- Day 5: Testing and review
  - Note: Some tests won't pass yet (SavingsAccount not implemented)
  - That's OK - they test abstract behavior

**Key Teaching Points**:
- Abstract classes define contracts
- Abstract methods force implementation in derived classes
- Static methods are utility functions
- Template Method pattern: structure in base, specifics in derived

**Discussion Questions**:
- "Why is CalculateInterestEarned() abstract but ApplyInterest() is not?"
- "When would you use a static method instead of instance method?"
- "What happens if you try to instantiate InterestBearingAccount directly?"

**Common Errors**:
- Implementing abstract methods instead of overriding in derived class
- Confusing static fields with instance fields
- Not initializing LastInterestDate

---

#### Week 4: Savings Account (5-6 hours)
**Goals**: Implement SavingsAccount, understand method override, business logic

**Pre-Class**:
- Students read BANKING_CURRICULUM.md "Savings Account" section
- Students review related tests to understand withdrawal limits

**Class Activities**:
- Day 1: Business requirements discussion
  - What are withdrawal limits? (Regulation D)
  - Why do banks have these rules?
  - How are penalties calculated?
  - Real-world examples from student bank accounts

- Day 2: Constructor implementation
  - Call base constructor
  - Initialize withdrawal tracking variables
  - Discuss: Why track in instance fields?

- Day 3: Override MakeWithdrawal (the complex part)
  - Check if new month - reset counter
  - Check withdrawal count against limit
  - Apply penalty if needed
  - Call base.MakeWithdrawal()
  - Hint: Compare DateTime.Now.Month with stored date's Month

- Day 4: Interest calculation
  - Calculate days since last interest
  - Call static CalculateSimpleInterest()
  - Return result

- Day 5: Helper methods
  - GetWithdrawalsThisMonth()
  - GetRemainingFreeWithdrawals()

- Day 6: Testing and debugging
  - Run: `dotnet test --filter "SavingsAccount"`
  - Debug common issues with month tracking
  - Print debug values to trace execution

**Key Teaching Points**:
- `override` keyword replaces parent behavior
- Business logic can be enforced in derived classes
- Multiple calls to same method might behave differently based on state
- Month tracking requires date arithmetic

**Debugging Strategy**:
```csharp
// Add debugging to track month changes
Console.WriteLine($"Current month: {DateTime.Now.Month}");
Console.WriteLine($"Stored month: {withdrawalCountDate.Month}");
Console.WriteLine($"Withdrawal count: {withdrawalsThisMonth}");
```

**Real-World Connection**:
- Regulation D: Federal Reserve limit of 6 withdrawals per month for savings
- Banks enforce this by charging fees for excess withdrawals
- This is why savings rates are often better than checking

**Common Errors**:
- Forgetting to reset counter monthly
- Penalty applied instead of preventing withdrawal
- Off-by-one errors in limit checking
- Date comparison logic incorrect

---

#### Week 5: Checking Account (4-5 hours)
**Goals**: Implement CheckingAccount, understand feature toggling, alternative designs

**Pre-Class**:
- Students read BANKING_CURRICULUM.md "Checking Account" section
- Students review CheckingAccountTests to understand expectations

**Class Activities**:
- Day 1: Checking account features discussion
  - Compare with Savings account (different rules!)
  - Overdraft protection - what is it?
  - Monthly maintenance fees
  - Balance tiers
  - Why these features?

- Day 2: Constructor and feature toggles
  - Initialize OverdraftProtectionEnabled = true
  - Initialize lastFeeDate
  - Discuss: Boolean flags for conditional behavior

- Day 3: Override MakeWithdrawal with overdraft protection
  - Check if would go negative
  - If protection ON and going negative, ALLOW it + charge fee
  - If protection OFF and going negative, throw exception
  - Different from SavingsAccount!

- Day 4: Monthly maintenance fee
  - Check if month has passed
  - Check if balance qualifies for waiver (minimum balance)
  - Charge fee if not waived
  - Update lastFeeDate

- Day 5: Interest calculation and helper methods
  - Interest usually zero for checking
  - IsFeeWaived() and GetMonthlyFee()

- Day 6: Testing
  - Run: `dotnet test --filter "CheckingAccount"`
  - Verify overdraft fee is charged correctly
  - Verify fee waiver logic

**Key Teaching Points**:
- Different account types have different rules for same operations
- Method override allows customization without changing base class
- Feature flags (boolean properties) enable runtime behavior changes
- Real-world accounts have complex tiered pricing

**Compare & Contrast**:
```
SavingsAccount:
- PREVENTS withdrawal beyond limit, charges penalty
- Interest bearing
- 6 free withdrawals

CheckingAccount:
- ALLOWS overdraft if enabled, charges fee
- Little/no interest
- No withdrawal limit
- Monthly maintenance fee
```

**Real-World Examples**:
- Show actual bank statements
- Discuss why checking has no withdrawal limit
- Explain overdraft fees in student context

**Common Errors**:
- Applying overdraft fee every withdrawal
- Not allowing negative balance when protection is on
- Fee waiver based on wrong condition
- Not tracking month for fee application

---

#### Week 6: Account Statements (6-8 hours)
**Goals**: Implement AccountStatement, master LINQ, understand reporting

**Pre-Class**:
- Students read BANKING_CURRICULUM.md "Statements" section
- Students study QUICK_REFERENCE.md LINQ section thoroughly
- Students review actual bank statements (bring examples)

**Class Activities**:
- Day 1: LINQ introduction
  - Where() - filtering
  - Sum() - aggregation
  - Average() - statistics
  - MaxBy() - finding max
  - Why LINQ instead of loops?

- Day 2: Statement requirements
  - What is a bank statement?
  - What information does it contain?
  - Opening balance vs closing balance
  - Deposits vs withdrawals
  - Time period filtering

- Day 3: Constructor and filtering
  - Filter transactions by date range
  - Calculate opening balance (before period)
  - Calculate closing balance (after period)
  - Hint: Use LINQ Where() for date filtering

- Day 4: Aggregation methods
  - GetTotalDeposits() - sum where amount > 0
  - GetTotalWithdrawals() - sum absolute value where amount < 0
  - GetAverageTransactionAmount() - average of all
  - Handle empty case (return 0)

- Day 5: Advanced LINQ
  - GetLargestTransaction() - MaxBy or OrderByDescending
  - GetTransactionsByType() - filter deposits vs withdrawals
  - GetNetChange() - closing - opening

- Day 6: Formatting
  - GetStatementSummary() - multi-line formatted output
  - String interpolation
  - Currency formatting (C, F2)

- Day 7: Testing and refinement
  - Run: `dotnet test --filter "AccountStatement"`
  - Debug LINQ queries
  - Verify calculations

**LINQ Deep Dive**:

```csharp
// Where - filter
var deposits = transactions.Where(t => t.Amount > 0);

// Sum - add up
decimal total = transactions.Sum(t => t.Amount);

// Average - mean
decimal avg = transactions.Average(t => t.Amount);

// MaxBy - find maximum (by a property)
var largest = transactions.MaxBy(t => Math.Abs(t.Amount));

// ToList - convert results
var depositsList = deposits.ToList();

// Chaining - combine operations
var totalDeposits = transactions
    .Where(t => t.Amount > 0)
    .Sum(t => t.Amount);
```

**Testing LINQ Queries**:

Have students trace through manually:
```
Transactions: [1000, 500, -200, 300, -50]
.Where(t => t.Amount > 0) → [1000, 500, 300]
.Sum(t => t.Amount) → 1800
```

**Real-World Connection**:
- Banks generate statements monthly
- Statements help with reconciliation
- Statements are legal records
- Online banking shows real-time statements

**Common Errors**:
- Wrong LINQ method (Sum instead of Average)
- Forgetting to convert results to List
- Date range filtering logic reversed
- Absolute value confusion in withdrawal calculation
- Nullable return type not handled

**Extension Challenges**:
- Categorize statement (group by category)
- Year-to-date totals
- Compare month to month
- Find patterns (recurring transactions)

---

## Assessment & Feedback

### Progress Tracking
Monitor test results:
```bash
# This tells you exactly what's working/broken
dotnet test --logger "console;verbosity=detailed"
```

### Code Review Checklist
- ✓ All unit tests pass
- ✓ Code compiles with no warnings
- ✓ Meaningful variable names
- ✓ Comments where needed
- ✓ No code duplication
- ✓ Proper exception handling
- ✓ Edge cases considered

### Feedback Rubric

**Excellent (90-100%)**
- All tests pass
- Clean, readable code
- Demonstrates deep understanding
- Handles edge cases
- Could explain to others

**Good (80-90%)**
- All tests pass
- Code is functional
- Some room for improvement
- Basic understanding evident

**Acceptable (70-80%)**
- Most tests pass
- Code works but unclear
- Limited understanding
- Basic functionality there

**Needs Work (<70%)**
- Tests failing
- Code has errors
- Incomplete implementation
- Misunderstood concepts

## Teaching Strategies

### Active Learning
- Don't just lecture code
- Have students write code during class
- Use pair programming occasionally
- Have students explain their code to peers

### Make It Real
- Use actual bank statements as examples
- Discuss real regulations (Reg D)
- Talk about their own bank accounts
- Discuss production banking software

### Debug Together
- When tests fail, debug as a group
- Show print statements for tracing
- Use visual debugger (breakpoints)
- Ask: "What did you expect? What happened?"

### Celebrate Progress
- Show test count increasing
- Celebrate when all tests pass
- Recognize good code quality
- Share interesting implementations

## Common Teaching Challenges

### "It's too hard"
**Response**: 
- Break it into smaller pieces
- Show how to debug step-by-step
- Reference working examples (Transaction, BankAccount)
- It's OK to struggle - that's learning

### "I don't understand inheritance"
**Response**:
- Use real-world analogy (checking/savings both are accounts)
- Draw diagrams showing hierarchy
- Show code side-by-side (parent vs child)
- Demonstrate what breaks if you remove base call

### "My tests are failing"
**Response**:
- Read the assertion failure carefully
- Calculate expected value manually
- Print debug values
- Compare with test code to understand expectations
- Check if you implemented all methods

### "This is boring"
**Response**:
- Show real banking use cases
- Let them extend with custom features
- Have friendly competition on code quality
- Discuss how this appears in production systems

## Extension Activities

### For Early Finishers
1. **Money Market Account**: Tiered interest rates based on balance
2. **Transfer Between Accounts**: Move money between accounts
3. **Recurring Transactions**: Automatic monthly payments
4. **Audit Logging**: Track who made changes and when
5. **Multi-Currency**: Support different currencies

### For Advancement
1. **Database Persistence**: Save accounts to database
2. **Web API**: Expose accounts via REST API
3. **Async Operations**: Implement async methods
4. **Design Patterns**: Identify patterns in code
5. **Production Code**: Review banking software on GitHub

## Resources for Instructors

### Documentation
- BANKING_CURRICULUM.md - Complete learning objectives
- README.md - Student getting started guide
- QUICK_REFERENCE.md - C# syntax reference
- Unit tests - Show expected behavior

### Tools
- Visual Studio Code with C# extension
- .NET 8.0+ SDK
- Terminal/Command prompt for running tests

### Discussion Topics
- Object-oriented design principles
- When to use inheritance vs composition
- Exception handling strategies
- LINQ vs traditional loops
- Financial software design considerations

## Troubleshooting

### Tests Won't Run
```bash
# Make sure you're in the right directory
cd CodeSchool

# Restore packages
dotnet restore

# Try again
dotnet test
```

### Compilation Errors
- Check class names match exactly
- Verify method signatures (parameters and return types)
- Look for typos in property names
- Make sure classes are in correct namespace

### Tests Fail on Student Code
- Have them read the test to understand expectations
- Run test with verbose output
- Print expected vs actual values
- Compare with working example code

### Month Tracking Issues
- Print DateTime.Now values
- Compare months using Month and Year properties
- Check reset logic
- Trace through manually

### LINQ Confusion
- Start simple: just Where()
- Add one thing at a time
- Print intermediate results
- Compare with manual loop version

## Success Stories to Highlight

When students complete the project:
- They've written 300+ lines of production-quality code
- They understand OOP deeply
- They can write LINQ queries
- They can explain their architecture
- They've written and passed 100+ tests

This is a real achievement! Celebrate it.

## Next Steps After Completion

- More advanced C# topics (SOLID, Patterns)
- Database integration (EF Core)
- Web APIs (ASP.NET Core)
- Production code review (GitHub projects)
- Real-world projects with your tech stack

---

**Good luck with your teaching! This project provides a solid foundation for understanding C# and OOP.**
