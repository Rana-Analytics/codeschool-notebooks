# AI Coding Agent Instructions for C# Notebooks Repository

## Project Overview
This repository contains interactive .NET Jupyter notebooks for learning C# and machine learning using C#. The project has four main categories:

- **csharp-101**: Beginner-friendly C# tutorials (15 modules from Hello World to Methods/Exceptions)
- **csharp-scenarios**: Real-world C# application examples  
- **machine-learning**: ML workflows with C# using AutoML, data processing, and model evaluation
- **notebook-getting-started**: User guides for working with .NET Interactive notebooks
- **CodeSchool**: Example C# code and associated unit tests for the purpose of teaching C# concepts.

## Target Environment
- **SDK**: .NET 8.0.+ (specified in `global.json`)
- **Language**: C# 9+ features acceptable (string interpolation, var inference, nullable reference types)
- **Code Format**: Notebooks are XML-based; Projects use standard `.csproj`/`.cs` files

## Critical Development Principles

### Code Organization
- **Solution files** (`.sln`) coordinate multiple projects in the root directory
- **Code projects** follow naming: `ProjectName.csproj` (contains business logic)
- **Test projects** follow naming: `ProjectName.Tests.csproj` (xUnit tests)
- Namespace hierarchy aligned with folder structure
- Public APIs documented with XML comments (`/// <summary>`, `/// <param>`, `/// <returns>`)

### Code Style & Quality
- Apply SOLID principles: Single Responsibility, interface-driven design
- Use dependency injection for testability (constructor injection preferred)
- Keep methods focused and small
- Use meaningful variable names reflecting intent
- Return early from methods to reduce nesting depth
- Prefer `private` or `internal` access; only expose `public` when needed

### What NOT to Do in Production Code
- Don't create untestable code (tight coupling, static dependencies)
- Don't add business logic to constructors (use factory methods or builders)
- Don't hardcode configuration values (use options pattern or configuration files)
- Don't leave `Console.WriteLine()` in production code (use proper logging)

## Security & Governance
- MIT License applies to all content
- .NET Foundation Code of Conduct in effect
- Security issues reported through MSRC (not GitHub issues)
- This repository follows Microsoft open-source standards

## Quick Reference: Key Files
- [README.md](../README.md) - Master index, all notebook tables
- [global.json](../global.json) - .NET SDK version specification
- [.tools/run_all_notebooks.ps1](.tools/run_all_notebooks.ps1) - CI execution script with skip list
- [csharp-101/](../csharp-101/) - Use as template for tutorial notebook structure
