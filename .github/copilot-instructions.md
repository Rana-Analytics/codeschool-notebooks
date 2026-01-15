# AI Coding Agent Instructions for C# Notebooks

## Project Overview
This repository contains interactive .NET Jupyter notebooks for learning C# and machine learning using C#. The project has four main categories:

- **csharp-101**: Beginner-friendly C# tutorials (15 modules from Hello World to Methods/Exceptions)
- **csharp-scenarios**: Real-world C# application examples  
- **machine-learning**: ML workflows with C# using AutoML, data processing, and model evaluation
- **notebook-getting-started**: User guides for working with .NET Interactive notebooks

## Key Architecture & File Format
- **Notebooks are XML-based** (`.ipynb` files contain `<VSCode.Cell>` elements)
- Cells alternate between `language="markdown"` (documentation) and `language="csharp"` (executable code)
- State persists across cells within a notebook session (variables defined in one cell are accessible in later cells)
- Markdown cells include instructional text, links to videos, and "Playground" sections for learner practice

## Development Workflow

### Running Notebooks
- Use `.tools/run_all_notebooks.ps1` for batch execution
- This PowerShell script skips known long-running notebooks (ML notebooks require NuGet downloads)
- Target SDK: .NET 8.0.117 (specified in `global.json`)

### Building & Testing .NET Solutions
- Solution files (`.sln`) coordinate multiple projects in the root directory
- Build projects: `dotnet build` in the solution root or specific `.csproj` directory
- Run all unit tests: `dotnet test` from solution root (runs all `*.Tests.csproj` projects)
- Run specific test project: `dotnet test ./path/to/ProjectName.Tests.csproj`
- Run tests with coverage: `dotnet test /p:CollectCoverage=true` (requires coverlet package)

### Content Structure Pattern
Each tutorial notebook typically follows this pattern:
1. **Introduction markdown** - links to video, documentation, learning objectives
2. **Concept explanation markdown** - introduces the topic
3. **Code cell** - working example with output
4. **Explanation markdown** - walks through what the code does
5. **Playground section** - prompts for learner practice with optional challenges
6. **Continue Learning section** - links to next module, videos, and docs

## Critical Conventions & Patterns

### Notebook Linking
- Modules link to each other sequentially: "⏩ Next Module" points to the subsequent notebook
- Raw GitHub URLs used for external links: `https://raw.githubusercontent.com/dotnet/csharp-notebooks/main/...`
- YouTube video links paired with notebooks for multimedia learning
- MS Learn documentation links included for deeper dives

### Code Examples
- Code should be **executable in isolation** or after prior cells in the notebook
- C# 9+ features acceptable (string interpolation, var inference)
- `Console.WriteLine()` is the primary output method for learners
- Variable state carries forward - avoid redefining previous examples unless intentional

### ML Notebooks (machine-learning/)
- Heavy dependency on NuGet packages (ML.NET, Pandas-like APIs)
- E2E notebooks demonstrate full workflows: data prep → training → evaluation
- Reference notebooks provide isolated deep dives into specific techniques
- CSV/TSV datasets stored in `data/` subdirectory

## .NET 8.0+ Project Structure & Conventions

### Project Organization
- **Solution file** (`.sln`) in repository root groups all projects
- **Code projects** follow naming: `ProjectName.csproj` (contains business logic)
- **Test projects** follow naming: `ProjectName.Tests.csproj` (xUnit tests for corresponding project)
- **Target framework**: `<TargetFramework>net8.0</TargetFramework>` in all `.csproj` files
- **Nullable reference types**: Enabled by default (`<Nullable>enable</Nullable>`)

### File & Folder Organization
- Source code in `src/` subdirectory per project: `src/ProjectName/ClassName.cs`
- Tests mirror source structure: `tests/ProjectName.Tests/ClassName.cs` or `ClassName.Tests.cs`
- Keep namespace hierarchy aligned with folder structure
- Use `namespaces` matching folder depth: `ProjectName.Features.SubFeature`

## Unit Testing with xUnit

### Test Project Setup
- Add xUnit reference to `.csproj`: `<PackageReference Include="xunit" Version="2.6.*"/>`
- Add test runner: `<PackageReference Include="xunit.runner.visualstudio" Version="2.5.*"/>`
- Test classes don't inherit from base; use `[Fact]` and `[Theory]` attributes
- Name test methods descriptively: `MethodName_Scenario_ExpectedResult()` or `Should_ReturnValue_WhenConditionMet()`

### Test Structure Pattern (AAA)
```csharp
[Fact]
public void Calculate_ValidInputs_ReturnsExpectedSum()
{
    // Arrange: Set up test data and dependencies
    var calculator = new Calculator();
    
    // Act: Execute the method under test
    var result = calculator.Add(2, 3);
    
    // Assert: Verify the outcome
    Assert.Equal(5, result);
}

[Theory]
[InlineData(1, 1, 2)]
[InlineData(5, 3, 8)]
public void Add_MultipleInputs_ReturnsCorrectSum(int a, int b, int expected)
{
    var calculator = new Calculator();
    Assert.Equal(expected, calculator.Add(a, b));
}
```

### Common Assertions
- `Assert.Equal(expected, actual)` - Equality checks
- `Assert.True/False(condition)` - Boolean conditions
- `Assert.Throws<Exception>(() => method())` - Exception verification
- `Assert.NotNull/Null(object)` - Null checks
- `Assert.Empty/NotEmpty(collection)` - Collection checks

## Mocking with Moq

### Moq Setup & Usage
- Add Moq: `<PackageReference Include="Moq" Version="4.20.*"/>`
- Create mocks for interfaces/abstract classes: `var mockService = new Mock<IUserService>();`
- Set up return values: `mockService.Setup(m => m.GetUser(It.IsAny<int>())).ReturnsAsync(testUser);`
- Verify calls: `mockService.Verify(m => m.DeleteUser(userId), Times.Once);`

### Common Moq Patterns
```csharp
// Setup return value for any input
mockService.Setup(m => m.GetName()).Returns("John");

// Setup with specific parameter matching
mockService.Setup(m => m.GetById(5)).Returns(expectedObject);

// Setup throwing exceptions
mockService.Setup(m => m.Delete(It.IsAny<int>()))
    .Throws(new InvalidOperationException());

// Verify method was called
mockService.Verify(m => m.Save(), Times.Once);
mockService.Verify(m => m.Log(It.IsAny<string>()), Times.AtLeastOnce);

// Async setup
mockService.Setup(m => m.GetUserAsync(It.IsAny<int>()))
    .ReturnsAsync(new User { Id = 1, Name = "Test" });
```

### Dependency Injection in Tests
- Use constructor injection in code classes to enable mocking
- Pass mocks to the class under test: `var service = new UserService(mockRepository.Object);`
- Prefer `Mock<IInterface>` over concrete classes for testability
- Use `It.IsAny<T>()` for flexible parameter matching in frequently-called methods

## When Modifying or Creating Content

### Notebook Content (Do's)
- Update markdown navigation links when reordering or adding notebooks
- Include video links alongside conceptual topics (found in README.md table)
- Test code cells incrementally across cell boundaries (shared state matters)
- Reference `csharp-101/` structure as template for new tutorial content
- Use string interpolation (`$"{variable}"`) over concatenation (`+`)
- Keep playground prompts actionable and progressive (try → modify → challenge)

### Notebook Content (Don'ts)
- Don't assume global imports beyond System/System.Collections
- Don't create notebooks without markdown learning context
- Don't break existing cell-to-cell dependencies when editing
- Don't use external file I/O in learner playgrounds (notebooks may run in isolated environments)

### .NET Project Code (Do's)
- Apply SOLID principles: Single Responsibility, interface-driven design
- Use dependency injection for testability (constructor injection preferred)
- Keep methods focused and small (easier to unit test)
- Document public APIs with XML comments (`/// <summary>`, `/// <param>`, `/// <returns>`)
- Use meaningful variable names reflecting intent
- Return early from methods to reduce nesting depth

### .NET Project Code (Don'ts)
- Don't create untestable code (tight coupling, static dependencies)
- Don't add business logic to constructors (use factory methods or builders)
- Don't make methods `public` unless needed (prefer `private` or `internal`)
- Don't leave Console.WriteLine() in production code (use proper logging)
- Don't hardcode configuration values (use options pattern or configuration files)

## Notable External Dependencies
- **Polyglot Notebooks extension** required in VS Code
- .NET Interactive kernel handles code execution
- ML.NET for machine learning notebooks
- NuGet packages auto-resolved during notebook execution

## Security & Governance
- MIT License applies to all content
- .NET Foundation Code of Conduct in effect
- Security issues reported through MSRC (not GitHub issues)
- This repository follows Microsoft open-source standards

## Quick Reference: Key Files
- [README.md](../README.md) - Master index, all notebook tables
- [global.json](../global.json) - .NET SDK version specification
- [.tools/run_all_notebooks.ps1](.tools/run_all_notebooks.ps1) - CI execution script with skip list
- [csharp-101/](../csharp-101/) - Use as template for tutorial structure
