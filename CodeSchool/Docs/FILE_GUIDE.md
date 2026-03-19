# BankingCS - Complete File Guide

A comprehensive index of all files in the BankingCS project with descriptions and intended audiences.

## Project Root Files

### Main Documentation
| File | Purpose | Audience | Time |
|------|---------|----------|------|
| [README.md](../README.md) | Getting started guide and quick start | Students (Primary), Instructors | 30 min |
| [Docs/BANKING_CURRICULUM.md](BANKING_CURRICULUM.md) | Complete learning curriculum and objectives | Instructors, Advanced Students | 2 hours |
| [Docs/QUICK_REFERENCE.md](QUICK_REFERENCE.md) | C# syntax and pattern reference | Students, Instructors | On-demand |
| [Docs/INSTRUCTOR_GUIDE.md](INSTRUCTOR_GUIDE.md) | Complete teaching guide | Instructors | 1.5 hours |
| [Docs/IMPLEMENTATION_SUMMARY.md](IMPLEMENTATION_SUMMARY.md) | Project overview and status | Instructors, Project Managers | 20 min |

---

## BankingCS/ - Source Code

### Completed Classes (Study & Reference)
| File | Lines | Purpose | Concepts | Status |
|------|-------|---------|----------|--------|
| [Transaction.cs](../BankingCS/Transaction.cs) | ~35 | Single transaction record | Properties, Immutability, Constructors | ✅ Complete |
| [BankAccount.cs](../BankingCS/BankAccount.cs) | ~120 | Basic account with deposits/withdrawals | Collections, Methods, Validation, Static | ✅ Complete |

### Framework Classes (Student Implementation)
| File | Lines | Purpose | Concepts | Difficulty |
|------|-------|---------|----------|------------|
| [CategorizedTransaction.cs](../BankingCS/CategorizedTransaction.cs) | ~50 | Categorized transactions | Inheritance, Enums, Constructor Chaining | 🟢 Easy |
| [InterestBearingAccount.cs](../BankingCS/InterestBearingAccount.cs) | ~150 | Abstract base for interest accounts | Abstract Classes, Polymorphism, Static Methods | 🟡 Medium |
| [SavingsAccount.cs](../BankingCS/SavingsAccount.cs) | ~120 | Savings with withdrawal limits | Override, Business Logic, Date Math | 🟡 Medium |
| [CheckingAccount.cs](../BankingCS/CheckingAccount.cs) | ~130 | Checking with overdraft & fees | Override, Feature Flags, Tiers | 🟡 Medium |
| [AccountStatement.cs](../BankingCS/AccountStatement.cs) | ~250 | Account reports & analysis | LINQ, Filtering, Aggregation | 🔴 Hard |

**Legend**:
- ✅ Complete - Fully implemented, study this
- 🟢 Easy - 1-2 hours for confident students
- 🟡 Medium - 3-5 hours, requires some debugging
- 🔴 Hard - 6-8 hours, challenging but rewarding

---

## BankingCS.Tests/ - Unit Tests

### Test Files
| File | Tests | Purpose | Audience |
|------|-------|---------|----------|
| [BankAccountTests.cs](../BankingCS.Tests/BankAccountTests.cs) | 40+ | Foundation class tests (Transaction, BankAccount) | Students learn from; should all pass |
| [CategorizedTransactionTests.cs](../BankingCS.Tests/CategorizedTransactionTests.cs) | 7 | CategorizedTransaction tests | Students implement against |
| [InterestBearingAccountTests.cs](../BankingCS.Tests/InterestBearingAccountTests.cs) | 5 | InterestBearingAccount tests | Students implement against |
| [SavingsAccountTests.cs](../BankingCS.Tests/SavingsAccountTests.cs) | 7 | SavingsAccount tests | Students implement against |
| [CheckingAccountTests.cs](../BankingCS.Tests/CheckingAccountTests.cs) | 8 | CheckingAccount tests | Students implement against |
| [AccountStatementTests.cs](../BankingCS.Tests/AccountStatementTests.cs) | 10+ | AccountStatement tests | Students implement against |

### Test Breakdown by Class
```
BankAccountTests.cs (40+ tests)
├── Transaction Tests (3)
├── BankAccount Constructor Tests (4)
├── BankAccount Property Tests (2)
├── BankAccount Deposit Tests (5)
├── BankAccount Withdrawal Tests (6)
├── BankAccount History Tests (3)
└── BankAccount Integration Tests (2)

CategorizedTransactionTests.cs (7 tests)
InterestBearingAccountTests.cs (5 tests)
SavingsAccountTests.cs (7 tests)
CheckingAccountTests.cs (8 tests)
AccountStatementTests.cs (10+ tests)
```

---

## Reading Order

### For Students - First Time
1. **../README.md** (30 min) - Project overview, getting started
2. **../BankingCS/Transaction.cs** (20 min) - Read and understand
3. **../BankingCS/BankAccount.cs** (30 min) - Read, run tests
4. **QUICK_REFERENCE.md** (as needed) - Syntax help
5. **Your assigned framework class** - Read comments
6. **Related tests** - Understand expectations

### For Instructors - First Time
1. **IMPLEMENTATION_SUMMARY.md** (20 min) - What exists
2. **BANKING_CURRICULUM.md** (1.5 hours) - Learning objectives
3. **INSTRUCTOR_GUIDE.md** (1.5 hours) - How to teach
4. **All source files** (1 hour) - Understand architecture
5. **All tests** (30 min) - Know what's expected

### For Reviewing Student Progress
1. Run `dotnet test -- --filter-class "BankingCS.Tests.CategorizedTransactionTests"` (or other class name)
2. Run `dotnet test` (see overall progress)
3. Check specific class tests
4. Review code in source files
5. Provide feedback based on test results

---

## File Purposes Quick Reference

### Learning Concepts
- **Want to learn about Properties?** → See Transaction.cs (read-only) and BankAccount.cs (read/write, computed)
- **Want to learn about Inheritance?** → See CategorizedTransaction.cs, InterestBearingAccount.cs
- **Want to learn about Abstract Classes?** → See InterestBearingAccount.cs
- **Want to learn about Override?** → See SavingsAccount.cs, CheckingAccount.cs
- **Want to learn about LINQ?** → See AccountStatement.cs
- **Want to learn about Validation?** → See BankAccount.cs MakeDeposit/MakeWithdrawal
- **Want to learn about Enums?** → See CategorizedTransaction.cs TransactionCategory
- **Want to learn about Static?** → See BankAccount.cs accountNumberSeed, InterestBearingAccount.cs CalculateSimpleInterest()

### Understanding Patterns
- **Template Method Pattern** → InterestBearingAccount.ApplyInterest() calling abstract CalculateInterestEarned()
- **Strategy Pattern** → Different interest calculation strategies (SavingsAccount vs CheckingAccount)
- **Feature Flags** → CheckingAccount.OverdraftProtectionEnabled
- **Immutability** → Transaction properties (read-only)

### Understanding Real-World Concepts
- **Why limits exist** → SavingsAccount withdrawal limits (Regulation D)
- **Why fees apply** → SavingsAccount penalties, CheckingAccount maintenance fee
- **How interest works** → InterestBearingAccount simple interest calculation
- **What statements show** → AccountStatement comprehensive report

---

## Using Tests to Learn

### Run Different Test Subsets
```bash
# All tests
dotnet test

# Only foundation tests (should all pass initially)
dotnet test -- --filter-class "BankingCS.Tests.BankAccountTests"

# Only specific framework tests
dotnet test -- --filter-class "BankingCS.Tests.SavingsAccountTests"
dotnet test -- --filter-class "BankingCS.Tests.CheckingAccountTests"
dotnet test -- --filter-class "BankingCS.Tests.CategorizedTransactionTests"
dotnet test -- --filter-class "BankingCS.Tests.AccountStatementTests"
dotnet test -- --filter-class "BankingCS.Tests.InterestBearingAccountTests"

# With detailed output
dotnet test --logger "console;verbosity=detailed"

# Stop after first failure
dotnet test --no-build --verbosity minimal
```

### Reading Test Output
```
PASS BankAccount_MakeDepositIncreasesBalance
  ✓ Test passed - your implementation works

FAIL SavingsAccount_FirstSixWithdrawalsAreFree
  ✓ Test ran
  ✗ Assertion failed: Expected 4800 but got 4750
  → Your implementation has a bug, likely in fee calculation
```

### Using Tests as Documentation
Tests ARE the specification. When in doubt:
1. Look at the test name - tells you what to test
2. Read the test code - shows expected behavior
3. Check assertion - shows what should happen
4. Run test - shows what's actually happening

---

## Progress Tracking

### Week 1: Foundation
- [ ] Read ../README.md
- [ ] Study ../BankingCS/Transaction.cs
- [ ] Study ../BankingCS/BankAccount.cs
- [ ] Run: `dotnet test -- --filter-class "BankingCS.Tests.BankAccountTests"`
- [ ] All tests passing

### Week 2: Categorization
- [ ] Implement ../BankingCS/CategorizedTransaction.cs
- [ ] Run: `dotnet test -- --filter-class "BankingCS.Tests.CategorizedTransactionTests"`
- [ ] All 7 tests passing

### Week 3: Abstract Classes
- [ ] Implement ../BankingCS/InterestBearingAccount.cs
- [ ] Read BANKING_CURRICULUM.md "Abstract Classes" section
- [ ] Tests may not all pass yet

### Week 4: Savings Account
- [ ] Implement ../BankingCS/SavingsAccount.cs
- [ ] Run: `dotnet test -- --filter-class "BankingCS.Tests.SavingsAccountTests"`
- [ ] All 7 tests passing

### Week 5: Checking Account
- [ ] Implement ../BankingCS/CheckingAccount.cs
- [ ] Run: `dotnet test -- --filter-class "BankingCS.Tests.CheckingAccountTests"`
- [ ] All 8 tests passing

### Week 6: Statements
- [ ] Implement ../BankingCS/AccountStatement.cs (hardest!)
- [ ] Run: `dotnet test -- --filter-class "BankingCS.Tests.AccountStatementTests"`
- [ ] All 10+ tests passing

### Final
- [ ] Run: `dotnet test` (all 66+ tests)
- [ ] Code review your implementations
- [ ] Celebrate completion!

---

## Help & Resources

### If You're Stuck On...

**Concepts**
- Use QUICK_REFERENCE.md for syntax
- Check BANKING_CURRICULUM.md for understanding
- Look at working examples in ../BankingCS/Transaction.cs and ../BankingCS/BankAccount.cs

**Implementation Details**
- Read the test to see expected behavior
- Print debug values with Console.WriteLine()
- Compare your code with similar working code
- Ask: "What should happen?" vs "What is happening?"

**Specific Errors**
- NotImplementedException → You need to implement the method
- NullReferenceException → Something isn't initialized
- Test assertions failing → Your calculation is wrong

**Understanding Tests**
- XUnit [Fact] = single test
- XUnit [Theory] [InlineData] = multiple test cases
- AAA Pattern: Arrange, Act, Assert
- See QUICK_REFERENCE.md for testing patterns

---

## File Statistics

### Code Size
```
Transaction.cs               ~35 lines    (Complete, immutable)
BankAccount.cs              ~120 lines    (Complete, core logic)
CategorizedTransaction.cs    ~50 lines    (Framework)
InterestBearingAccount.cs   ~150 lines    (Abstract framework)
SavingsAccount.cs           ~120 lines    (Framework)
CheckingAccount.cs          ~130 lines    (Framework)
AccountStatement.cs         ~250 lines    (Framework)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
TOTAL                       ~850 lines
```

### Test Coverage
```
BankAccountTests.cs              25+ tests (Foundation)
CategorizedTransactionTests.cs    9  tests (Framework)
InterestBearingAccountTests.cs    5  tests (Framework)
SavingsAccountTests.cs            7  tests (Framework)
CheckingAccountTests.cs           9  tests (Framework)
AccountStatementTests.cs         11+ tests (Framework)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
TOTAL                            66+ tests
```

### Documentation
```
../README.md                ~300 lines (Getting started)
BANKING_CURRICULUM.md       ~400 lines (Complete curriculum)
QUICK_REFERENCE.md          ~400 lines (C# reference)
INSTRUCTOR_GUIDE.md         ~500 lines (Teaching guide)
IMPLEMENTATION_SUMMARY.md   ~200 lines (Overview)
FILE_GUIDE.md              ~300 lines (This file)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
TOTAL                       ~2100 lines
```

---

## Key Learning Milestones

### 🎯 Foundation (Week 1)
✅ Understand properties and immutability
✅ Understand constructors and initialization
✅ Understand exception handling
✅ Understand collections (List<T>)
✅ Understand static members

### 🎯 Intermediate (Weeks 2-3)
✅ Understand inheritance and base keyword
✅ Understand enums and type safety
✅ Understand abstract classes
✅ Understand abstract methods and contracts
✅ Understand static utility methods

### 🎯 Advanced (Weeks 4-6)
✅ Understand method override and polymorphism
✅ Understand method override and polymorphism
✅ Can enforce business logic in derived classes
✅ Understand feature flags and runtime customization
✅ Master LINQ queries (Where, Sum, Average, MaxBy)
✅ Understand nullable types and optional results
✅ Can analyze and report on data

---

## Success Checklist

Project complete when:
- [ ] All 66+ tests pass
- [ ] No compilation errors or warnings
- [ ] Code follows C# naming conventions
- [ ] Methods are focused (single responsibility)
- [ ] Comments explain complex logic
- [ ] Edge cases are handled
- [ ] Understands OOP principles
- [ ] Can explain inheritance hierarchy
- [ ] Can write LINQ queries
- [ ] Can debug own code

---

**For detailed information on any file, see its header comments or README section.**
