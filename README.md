# Library Management System

Small System for Library Management via terminal, using C# .NET Core.

## Functionalities

- Add, update, remove, and list books
- Validate ISBN (13 digits)
- Repository layer using in-memory storage
- Tests with xUnit

## Estructure

- `Models/` – Data Models
- `Repositories/` – Interfaces and implementations for data access
- `Services/` – Business logic
- `Program.cs` – Interface via console
- `Tests/` – Xunit tests

## Requirements

- .NET Core 8
- xUnit 

## Execution

```bash
dotnet run
