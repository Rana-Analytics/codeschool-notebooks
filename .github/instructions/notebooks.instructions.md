applyTo: "**/*.ipynb"

# AI Instructions for Polyglot Notebooks

## Notebook Architecture & File Format
- **Notebooks are XML-based** (`.ipynb` files contain `<VSCode.Cell>` elements)
- Cells alternate between `language="markdown"` (documentation) and `language="csharp"` (executable code)
- State persists across cells within a notebook session (variables defined in one cell are accessible in later cells)
- Markdown cells include instructional text, links to videos, and "Playground" sections for learner practice
- Code cells must be executable using the .NET Interactive kernel (Polyglot Notebooks extension)

## Running & Testing Notebooks
- Use `.tools/run_all_notebooks.ps1` for batch execution
- This PowerShell script skips known long-running notebooks (ML notebooks require NuGet downloads)
- Individual notebooks can be executed in VS Code via the "Run All" button or cell-by-cell with play icons
- Notebooks persist state across cells—test incrementally across cell boundaries

## Content Structure Pattern
Each tutorial notebook typically follows this pattern:
1. **Introduction markdown** - links to video, documentation, learning objectives
2. **Concept explanation markdown** - introduces the topic
3. **Code cell** - working example with output
4. **Explanation markdown** - walks through what the code does
5. **Playground section** - prompts for learner practice with optional challenges
6. **Continue Learning section** - links to next module, videos, and docs

## Notebook Linking Conventions
- Modules link to each other sequentially: "⏩ Next Module" points to the subsequent notebook
- Raw GitHub URLs used for external links: `https://raw.githubusercontent.com/dotnet/csharp-notebooks/main/...`
- YouTube video links paired with notebooks for multimedia learning
- MS Learn documentation links included for deeper dives
- Always include "Continue Learning" section with navigation and resource links

## Code Examples in Notebooks
- Code should be **executable in isolation** or after prior cells in the notebook
- Use C# 9+ features (string interpolation, var inference)
- `Console.WriteLine()` is the primary output method for learners
- Variable state carries forward—avoid redefining previous examples unless intentional
- Assume only System and System.Collections imports; declare others explicitly in cells

## ML Notebooks (machine-learning/)
- Heavy dependency on NuGet packages (ML.NET, Pandas-like APIs)
- E2E notebooks demonstrate full workflows: data prep → training → evaluation
- Reference notebooks provide isolated deep dives into specific techniques
- CSV/TSV datasets stored in `machine-learning/data/` subdirectory
- Notebooks may require additional setup time due to package downloads (see skip list in .tools/)

## When Modifying or Creating Notebook Content

### Do's
- Update markdown navigation links when reordering or adding notebooks
- Include video links alongside conceptual topics (found in README.md table)
- Test code cells incrementally across cell boundaries (shared state matters)
- Reference `csharp-101/` structure as template for new tutorial content
- Use string interpolation (`$"{variable}"`) over concatenation (`+`)
- Keep playground prompts actionable and progressive (try → modify → challenge)

### Don'ts
- Don't assume global imports beyond System/System.Collections
- Don't create notebooks without markdown learning context
- Don't break existing cell-to-cell dependencies when editing
- Don't use external file I/O in learner playgrounds (notebooks may run in isolated environments)
- Don't reference Cell IDs in documentation or comments

## Notable External Dependencies
- **Polyglot Notebooks extension** (ms-dotnettools.dotnet-interactive-vscode) required in VS Code
- .NET Interactive kernel handles code execution
- ML.NET for machine learning notebooks
- NuGet packages auto-resolved during notebook execution
