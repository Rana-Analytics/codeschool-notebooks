# BankingCS Project Index

**Complete, production-ready C# learning project with 7 classes, 110+ tests, and comprehensive documentation.**

---

## 🚀 Quick Start (5 minutes)

### For Students
```bash
cd CodeSchool
dotnet test  # See all tests
```
Then read: **README.md** → [Getting Started](README.md)

### For Instructors
Read in this order:
1. **DELIVERY_SUMMARY.md** (2 min) - Project overview
2. **INSTRUCTOR_GUIDE.md** (30 min) - Teaching strategy
3. **BANKING_CURRICULUM.md** (1 hour) - Learning objectives

---

## 📂 Project Structure

```
CodeSchool/
├── BankingCS/                          # Source Code
│   ├── Transaction.cs                  ✅ Complete (study this)
│   ├── BankAccount.cs                  ✅ Complete (study this)
│   ├── CategorizedTransaction.cs       🔧 Student: Implement
│   ├── InterestBearingAccount.cs       🔧 Student: Implement
│   ├── SavingsAccount.cs               🔧 Student: Implement
│   ├── CheckingAccount.cs              🔧 Student: Implement
│   └── AccountStatement.cs             🔧 Student: Implement
├── BankingCS.Tests/                    # Unit Tests
│   ├── UnitTest1.cs                    ✅ 40+ Foundation Tests
│   └── StudentFrameworkTests.cs        🔧 70+ Framework Tests
├── Documentation/
│   ├── README.md                       📚 Getting Started
│   ├── BANKING_CURRICULUM.md           📚 Complete Curriculum
│   ├── QUICK_REFERENCE.md              📚 C# Syntax Reference
│   ├── INSTRUCTOR_GUIDE.md             📚 Teaching Guide
│   ├── IMPLEMENTATION_SUMMARY.md       📚 What Was Created
│   ├── FILE_GUIDE.md                   📚 File Index
│   └── DELIVERY_SUMMARY.md             📚 Project Summary
└── CodeSchool.sln                      Solution file
```

---

## 📚 Documentation Guide

### For Students
| Document | Purpose | Time | When to Read |
|-----------|---------|------|-------------|
| [README.md](README.md) | Getting started guide | 30 min | First! |
| [QUICK_REFERENCE.md](QUICK_REFERENCE.md) | C# syntax help | On-demand | When stuck |
| [BANKING_CURRICULUM.md](BANKING_CURRICULUM.md#key-concepts-covered) | Concept explanation | As needed | To understand concepts |

### For Instructors
| Document | Purpose | Time | When to Read |
|-----------|---------|------|-------------|
| [DELIVERY_SUMMARY.md](DELIVERY_SUMMARY.md) | Project overview | 2 min | First! |
| [INSTRUCTOR_GUIDE.md](INSTRUCTOR_GUIDE.md) | Complete teaching plan | 30 min | Plan your course |
| [BANKING_CURRICULUM.md](BANKING_CURRICULUM.md) | Learning objectives | 1 hour | Understand depth |
| [FILE_GUIDE.md](FILE_GUIDE.md) | Navigate all files | As needed | When looking for something |

---

## 🎯 Learning Path

### Phase 1: Foundation (Week 1)
- **Study**: Transaction.cs, BankAccount.cs
- **Run**: `dotnet test --filter "BankAccount"`
- **Expected**: 40+ tests passing
- **Time**: 2-3 hours

### Phase 2: Categorization (Week 2)
- **Implement**: CategorizedTransaction.cs
- **Concepts**: Inheritance, Enums, Constructor chaining
- **Run**: `dotnet test --filter "CategorizedTransaction"`
- **Time**: 3-4 hours

### Phase 3: Abstract Classes (Week 3)
- **Implement**: InterestBearingAccount.cs
- **Concepts**: Abstract classes, Static methods, Template Method pattern
- **Run**: `dotnet test --filter "InterestBearing"`
- **Time**: 4-5 hours

### Phase 4: Savings Account (Week 4)
- **Implement**: SavingsAccount.cs
- **Concepts**: Method override, Business logic, State tracking
- **Run**: `dotnet test --filter "SavingsAccount"`
- **Time**: 5-6 hours

### Phase 5: Checking Account (Week 5)
- **Implement**: CheckingAccount.cs
- **Concepts**: Alternative implementations, Feature flags, Tiered logic
- **Run**: `dotnet test --filter "CheckingAccount"`
- **Time**: 4-5 hours

### Phase 6: Statements (Week 6)
- **Implement**: AccountStatement.cs
- **Concepts**: LINQ, Filtering, Aggregation, Reporting
- **Run**: `dotnet test --filter "AccountStatement"`
- **Time**: 6-8 hours

---

## 🔍 Finding What You Need

### Learning a Concept?
- **Properties**: See Transaction.cs (immutable) and BankAccount.cs (read/write, computed)
- **Inheritance**: See CategorizedTransaction.cs
- **Abstract Classes**: See InterestBearingAccount.cs
- **Override**: See SavingsAccount.cs and CheckingAccount.cs
- **LINQ**: See AccountStatement.cs
- **Testing**: See both test files for patterns

### Stuck on Implementation?
1. **Read the TODO comment** in the source file
2. **Look at the test** to understand expectations
3. **Check QUICK_REFERENCE.md** for syntax
4. **Compare with working code** (Transaction or BankAccount)
5. **Print debug values** to trace execution

### Understanding Requirements?
1. **Read the unit test** for that method
2. **Check BANKING_CURRICULUM.md** for context
3. **Ask: What should happen?** (from test)
4. **Compare with real banking** to understand why

---

## ✅ How to Know You're Done

### Foundation (Week 1)
✅ Can explain why Transaction.Amount is read-only  
✅ Can explain how static accountNumberSeed works  
✅ Understand validation and exception throwing  
✅ Run `dotnet test --filter "BankAccount"` → All pass

### Categorization (Week 2)
✅ Understand inheritance and base keyword  
✅ Can use enums for type safety  
✅ Run `dotnet test --filter "CategorizedTransaction"` → All pass

### Abstract Classes (Week 3)
✅ Understand abstract classes and contracts  
✅ Understand static utility methods  
✅ Understand Template Method pattern  
✅ Run `dotnet test --filter "InterestBearing"` → No failures

### Savings (Week 4)
✅ Can override methods  
✅ Can enforce business logic  
✅ Can track state across calls  
✅ Run `dotnet test --filter "SavingsAccount"` → All pass

### Checking (Week 5)
✅ Can implement alternative designs  
✅ Understand feature flags  
✅ Understand tiered logic  
✅ Run `dotnet test --filter "CheckingAccount"` → All pass

### Statements (Week 6)
✅ Can write LINQ queries  
✅ Can filter and aggregate collections  
✅ Can format output  
✅ Run `dotnet test --filter "AccountStatement"` → All pass

### COMPLETION
✅ Run `dotnet test` → 110+ tests pass  
✅ No compilation errors  
✅ Clean, readable code  
✅ Understand OOP principles

---

## 🆘 Help & Troubleshooting

### Tests Won't Run
```bash
cd CodeSchool
dotnet restore
dotnet test
```

### Specific Test Fails
```bash
# Run just that test with details
dotnet test --filter "SavingsAccount" --logger "console;verbosity=detailed"
```

### Don't Understand a Concept
1. Check **QUICK_REFERENCE.md** for syntax
2. Check **BANKING_CURRICULUM.md** for explanation
3. Look at **working examples** (Transaction.cs, BankAccount.cs)
4. Check the **test** to see expected behavior

### Can't Figure Out Implementation
1. Print debug values: `Console.WriteLine($"value: {variable}");`
2. Read the unit test to understand what's expected
3. Calculate expected result manually
4. Compare your logic with the test assertion

---

## 📊 Project Statistics

```
Source Code:          ~850 lines (7 classes, 2 complete + 5 frameworks)
Unit Tests:           ~1500 lines (110+ tests)
Documentation:        ~2100 lines (6 comprehensive guides)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
TOTAL:               ~4450 lines

Student Time:         30-40 hours to complete
Instructor Setup:     1-2 hours initial review
Weekly Teaching:      2-3 hours per week
Difficulty:           Beginner to Intermediate
```

---

## 🎓 What You'll Learn

**Object-Oriented Programming**
- Classes, objects, and encapsulation
- Inheritance and polymorphism
- Abstract classes and interfaces
- Method overriding and customization
- Static members and utility methods

**Collections & LINQ**
- List<T> and iteration
- LINQ queries (Where, Sum, Average, MaxBy)
- Filtering and aggregation
- Nullable types

**Professional Practices**
- Exception handling
- Input validation
- Unit testing (AAA pattern)
- Code documentation
- Naming conventions

**Domain Knowledge**
- Banking concepts
- Financial calculations
- Regulatory requirements
- Business logic enforcement

---

## 🚀 Running the Project

### Get Started
```bash
cd CodeSchool
```

### Run All Tests
```bash
dotnet test
```

### Run Specific Tests
```bash
dotnet test --filter "BankAccount"           # Foundation
dotnet test --filter "SavingsAccount"        # Specific class
dotnet test --filter "Withdrawal"            # Specific method
```

### Verbose Output
```bash
dotnet test --logger "console;verbosity=detailed"
```

### Build Only
```bash
dotnet build
```

---

## 📖 Reading Order

### Students (First Time)
1. [README.md](README.md) - 30 min
2. Study Transaction.cs - 20 min
3. Study BankAccount.cs - 30 min
4. Run tests - 10 min
5. Pick a framework class - depends on phase

### Instructors (First Time)
1. [DELIVERY_SUMMARY.md](DELIVERY_SUMMARY.md) - 2 min
2. [INSTRUCTOR_GUIDE.md](INSTRUCTOR_GUIDE.md) - 30 min
3. [BANKING_CURRICULUM.md](BANKING_CURRICULUM.md) - 1 hour
4. Review source code - 1 hour
5. Review tests - 30 min

### Reviewing Progress
1. Run `dotnet test --filter "StudentName"`
2. Check specific test outputs
3. Review code in source files
4. Provide feedback based on tests

---

## 🎯 Success Indicators

✅ Foundation tests all passing (Week 1)  
✅ CategorizedTransaction tests all passing (Week 2)  
✅ SavingsAccount tests all passing (Week 4)  
✅ CheckingAccount tests all passing (Week 5)  
✅ AccountStatement tests all passing (Week 6)  
✅ All 110+ tests passing (Final)  
✅ Code compiles with no warnings  
✅ Understand OOP principles  

---

## 🔗 Quick Links

### Documentation
- [README - Getting Started](README.md)
- [INSTRUCTOR_GUIDE - Teaching Strategy](INSTRUCTOR_GUIDE.md)
- [BANKING_CURRICULUM - Learning Objectives](BANKING_CURRICULUM.md)
- [QUICK_REFERENCE - C# Syntax Help](QUICK_REFERENCE.md)
- [FILE_GUIDE - File Index](FILE_GUIDE.md)

### Source Code
- [Transaction.cs](BankingCS/Transaction.cs) - Study
- [BankAccount.cs](BankingCS/BankAccount.cs) - Study
- [CategorizedTransaction.cs](BankingCS/CategorizedTransaction.cs) - Implement
- [InterestBearingAccount.cs](BankingCS/InterestBearingAccount.cs) - Implement
- [SavingsAccount.cs](BankingCS/SavingsAccount.cs) - Implement
- [CheckingAccount.cs](BankingCS/CheckingAccount.cs) - Implement
- [AccountStatement.cs](BankingCS/AccountStatement.cs) - Implement

### Tests
- [UnitTest1.cs](BankingCS.Tests/UnitTest1.cs) - Foundation tests
- [StudentFrameworkTests.cs](BankingCS.Tests/StudentFrameworkTests.cs) - Framework tests

---

## 💡 Tips for Success

1. **Read the tests** - They're the specification
2. **Start simple** - Foundation classes are complete, study them
3. **Debug with prints** - `Console.WriteLine()` is your friend
4. **Small steps** - Implement one method at a time
5. **Run tests frequently** - See progress immediately
6. **Ask questions** - Read docs, check examples, understand concepts
7. **Don't give up** - Struggling is learning
8. **Celebrate progress** - Each passing test is a win

---

## 📞 Support Resources

- **C# Questions**: See QUICK_REFERENCE.md
- **Concept Questions**: See BANKING_CURRICULUM.md
- **Teaching Questions**: See INSTRUCTOR_GUIDE.md
- **Implementation Help**: Look at working classes (Transaction, BankAccount)
- **Test Failures**: Read test code to understand expectations
- **Debugging**: Add print statements and trace execution

---

**Start with README.md → Then follow the learning path → Run tests frequently**

Good luck! 🎓
