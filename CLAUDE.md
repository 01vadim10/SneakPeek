# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

SneakPeek is an ASP.NET Core 9.0 web application that helps users discover if movies have post-credits scenes. The application uses Clean Architecture with separate layers for Domain, Application, and Persistence, plus a Blazor Server frontend.

## Architecture

The solution follows Clean Architecture patterns:

- **Domain**: Core business entities and interfaces (`Movie` model, `IMoviesRepository`)
- **Application**: Business logic layer (currently minimal)
- **Persistence**: Data access layer with Entity Framework Core and SQLite
- **SneakPeek**: Web layer with Blazor Server components and API controllers

The main web project uses:
- Blazor Server with interactive components
- ASP.NET Core Web API controllers
- Entity Framework Core with In-Memory database for development
- Dependency injection for repository pattern

## Development Commands

### Build and Run
```bash
# Build the solution
dotnet build SneakPeek/SneakPeek.sln

# Run the web application
dotnet run --project SneakPeek/SneakPeek.csproj

# Or from the SneakPeek directory:
cd SneakPeek
dotnet run
```

### Testing
```bash
# Run unit tests
dotnet test SneakPeak.Tests/SneakPeak.Tests.csproj

# Run integration tests
dotnet test SneakPeak.IntegrationTests/SneakPeak.IntegrationTests.csproj

# Run all tests
dotnet test SneakPeek/SneakPeek.sln
```

The test projects use:
- xUnit as the test framework
- FluentAssertions for more readable assertions
- Entity Framework InMemory database for testing
- ASP.NET Core Test Host for integration tests

### Database
The application uses Entity Framework Core with:
- SQLite for production (configured in Persistence layer)
- In-Memory database for development and testing
- Code-first approach with `DataContext`

## Key Files and Patterns

- **Program.cs**: Application startup, dependency injection configuration
- **DataContext.cs**: Entity Framework database context
- **MoviesRepository.cs**: Repository implementation for data access
- **MoviesController.cs**: API controller (currently reads from JSON file)
- **Movie.cs**: Domain entity with JSON serialization attributes

## Project Structure Notes

- The solution file is located at `SneakPeek/SneakPeek.sln`
- There are some naming inconsistencies (SneakPeek vs SneakPeak) in test project names
- The main project references Domain and Persistence layers
- Test projects reference the main SneakPeek project
- The application is currently transitioning from file-based JSON storage to database storage via the repository pattern
