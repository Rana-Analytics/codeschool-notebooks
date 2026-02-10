applyTo: "**/*.cs,**/*.csproj,**/*.sln"

# AI Instructions for C# Projects, Solutions, and Tests

## General Code Generation Instructions
- Always create a NEW BRANCH when you start working on a feature or bugfix.
- Write clean, maintainable, and well-documented code.
- Always create unit tests for classes and methods you generate.
- Always run tests before comitting code.
- Follow .NET naming conventions: PascalCase for classes/methods, camelCase for local variables, _camelCase for private fields.
- Use XML documentation comments for classes, methods, and public APIs.
- Ensure generated code is compatible with .NET 8.0 and C# 9+
- Always use async/await for I/O-bound operations.

## .NET 8.0+ Project Structure & Conventions

### Project Organization
- **Solution file** (`.sln`) in repository root groups all projects
- **Code projects** follow naming: `ProjectName.csproj` (contains business logic)
- **Test projects** follow naming: `ProjectName.Tests.csproj` (xUnit tests for corresponding project)
- **Target framework**: `<TargetFramework>net8.0</TargetFramework>` in all `.csproj` files
- **Nullable reference types**: Enabled by default (`<Nullable>enable</Nullable>`)

### File & Folder Organization
- Source code in `src/` subdirectory per project: `src/ProjectName/ClassName.cs`
- Tests MUST mirror source structure: `tests/ProjectName.Tests/ClassName.cs` or `ClassNameTests.cs`, keeping same folder hierarchy and having one tests file per source file
- Test data and mocks in `tests/ProjectName.Tests/TestData/` or `Mocks/`
- Keep namespace hierarchy aligned with folder structure
- Use `namespaces` matching folder depth: `ProjectName.Features.SubFeature`

## Building & Testing .NET Solutions

### Build Commands
- Build all projects: `dotnet build` in the solution root
- Build specific project: `dotnet build ./src/ProjectName/ProjectName.csproj`
- Clean before rebuild: `dotnet clean` then `dotnet build`

### Test Execution
- Run all unit tests: `dotnet test` from solution root (runs all `*.Tests.csproj` projects)
- Run specific test project: `dotnet test ./tests/ProjectName.Tests/ProjectName.Tests.csproj`
- Run tests with coverage: `dotnet test /p:CollectCoverage=true` (requires coverlet package)
- Watch mode for development: `dotnet watch --project ./tests/ProjectName.Tests test`

## Unit Testing with xUnit

### Test Project Setup
- Using xUnit reference to `.csproj`: `<PackageReference Include="xunit.v3" Version="3.*"/>`
- Using test runner: `<PackageReference Include="xunit.runner.visualstudio" Version="3.*"/>`
- Test classes don't inherit from base class; use `[Fact]` and `[Theory]` attributes
- Name test methods descriptively: `MethodName_Scenario_ExpectedResult()` or `Should_ReturnValue_WhenConditionMet()`

### Test Structure Pattern (AAA - Arrange/Act/Assert)
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
- `Assert.True(condition)` / `Assert.False(condition)` - Boolean conditions
- `Assert.Throws<Exception>(() => method())` - Exception verification
- `Assert.NotNull(object)` / `Assert.Null(object)` - Null checks
- `Assert.Empty(collection)` / `Assert.NotEmpty(collection)` - Collection checks
- `Assert.Contains(item, collection)` / `Assert.DoesNotContain(item, collection)` - Membership checks

## Mocking with Moq

### Setup & Usage
- Using Moq: `<PackageReference Include="Moq" Version="4.20.*"/>`
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

## When Writing C# Code

### Design Principles (Do's)
- Apply SOLID principles: Single Responsibility, interface-driven design
- Use dependency injection for testability (constructor injection preferred)
- Keep methods focused and small (easier to unit test)
- Document public APIs with XML comments (`/// <summary>`, `/// <param>`, `/// <returns>`)
- Use meaningful variable names reflecting intent
- Return early from methods to reduce nesting depth

### Code Pitfalls (Don'ts)
- Don't create untestable code (tight coupling, static dependencies)
- Don't add business logic to constructors (use factory methods or builders)
- Don't make methods `public` unless needed (prefer `private` or `internal`)
- Don't leave `Console.WriteLine()` in production code (use proper logging)
- Don't hardcode configuration values (use options pattern or configuration files)
