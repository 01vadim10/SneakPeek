# SneakPeek

SneakPeek is a web application that helps moviegoers determine if there are after-credits scenes in movies, so you know whether to stay in the cinema after the main feature.

## .NET 9 & .NET Aspire

This project targets **.NET 9** and uses the latest **.NET Aspire** components for cloud-native development.

- Target Framework: `net9.0`
- Aspire Hosting: [Aspire.Hosting NuGet](https://www.nuget.org/packages/Aspire.Hosting)
- Aspire Orchestration: See `aspire/SneakPeek.Aspire` for orchestration and cloud-native setup

### Aspire Projects

- `aspire/SneakPeek.Aspire.AppHost`: .NET Aspire AppHost project orchestrating the SneakPeek API and other services
- `aspire/SneakPeek.Aspire.ServiceDefaults`: Aspire service defaults for shared configuration

The Aspire AppHost references the SneakPeek API project for integrated orchestration.

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022+ or VS Code

### Build and Run

1. Restore dependencies:
   ```pwsh
   dotnet restore SneakPeek.sln
   ```
2. Build the solution:
   ```pwsh
   dotnet build SneakPeek.sln
   ```
3. Run the Aspire orchestrator:
   ```pwsh
   dotnet run --project aspire/SneakPeek.Aspire/SneakPeek.Aspire.AppHost/SneakPeek.Aspire.AppHost.csproj
   ```

### Running Tests

To run all tests:

```pwsh
dotnet test SneakPeek.sln
```

## Project Purpose

SneakPeek helps users find out if a movie has after-credits scenes, so you never miss extra content at the cinema.

---

Feel free to contribute or open issues for suggestions and bug reports.
