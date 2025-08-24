# SneakPeek

<div align="center">
  <img src="assets/sneak-peek-icon.jpg" alt="SneakPeek Icon" width="200" height="200" style="border-radius: 10px;">
</div>

SneakPeek is a web application that helps moviegoers determine if there are after-credits scenes in movies, so you know whether to stay in the cinema after the main feature.

## Architecture & Technology Stack

This project follows **Clean Architecture** principles with **.NET 9** and **.NET Aspire** for cloud-native development.

### Technology Stack
- **Framework**: .NET 9 with Blazor Server
- **Database**: SQLite with Entity Framework Core
- **Architecture**: Clean Architecture (Domain, Application, Persistence layers)
- **Cloud-Native**: .NET Aspire orchestration
- **Frontend**: Blazor Server Components with Interactive Server Rendering

### Project Structure
- **Domain**: Core business entities (`Movie` model) and interfaces (`IMoviesRepository`)
- **Persistence**: Data access layer with Entity Framework Core and SQLite
- **SneakPeek**: Web application with Blazor Server components and API controllers
- **Aspire**: Cloud-native orchestration and service defaults

### Database
- **Provider**: SQLite (`SneakPeek.db`)
- **ORM**: Entity Framework Core with Code-First approach
- **Migrations**: Automatic database migration on application startup
- **Repository Pattern**: Full CRUD operations through `MoviesRepository`

### Data Model
The `Movie` entity includes:
```csharp
public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Wait { get; set; }           // Post-credits indicator
    public string Description { get; set; }
    public string Release_date { get; set; }
    public string Genre { get; set; }
    public List<string> Directors { get; set; }
    public double Rating { get; set; }
}
```

### API Endpoints
- `GET /movies` - Retrieve all movies from database
- Repository methods available for full CRUD operations:
  - `GetAllMoviesAsync()` - Get all movies
  - `GetMovieByIdAsync(int id)` - Get movie by ID
  - `AddMovieAsync(Movie movie)` - Add new movie
  - `UpdateMovieAsync(Movie movie)` - Update existing movie
  - `DeleteMovieAsync(int id)` - Delete movie by ID

### Aspire Projects
- `aspire/SneakPeek.Aspire.AppHost`: .NET Aspire AppHost project orchestrating the SneakPeek API and other services
- `aspire/SneakPeek.Aspire.ServiceDefaults`: Aspire service defaults for shared configuration

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
   dotnet run --project aspire/SneakPeek.Aspire.AppHost/SneakPeek.Aspire.AppHost.csproj
   ```

### Running Tests

To run all tests:

```pwsh
dotnet test SneakPeek.sln
```

#### Test Projects

- **Unit Tests**: `tests/SneakPeek.Tests/` - xUnit tests for business logic and repositories
- **Integration Tests**: `tests/SneakPeek.IntegrationTests/` - API controller integration tests
- **E2E Tests**: `tests/SneakPeek.E2E.Tests/` - Playwright end-to-end automation tests

#### QA Test Automation

The project uses **Playwright** with TypeScript for end-to-end testing automation:

```bash
# Navigate to E2E tests directory
cd tests/SneakPeek.E2E.Tests/

# Install dependencies
npm install

# Run E2E tests
npm test

# Run tests in headed mode
npm run test:headed

# Run specific test suite
npm run test:movies
```

**Test Structure:**
```
tests/SneakPeek.E2E.Tests/
├── tests/
│   ├── movies/
│   │   ├── movie-list.spec.ts        # Home.razor component tests
│   │   └── movie-details.spec.ts     # Movie data display tests
│   ├── api/
│   │   └── movies-api.spec.ts        # MoviesController API tests
│   └── visual/
│       └── ui-regression.spec.ts     # Visual consistency tests
├── page-objects/
│   ├── base-page.ts
│   ├── home-page.ts                  # Home.razor page object
│   └── movie-list-component.ts       # Movie list interactions
├── fixtures/
│   ├── movie-test-data.json          # Test data for database seeding
│   └── database-setup.ts             # Database setup and teardown utilities
└── utils/
    ├── api-helpers.ts                # MoviesController test utilities
    ├── repository-helpers.ts         # Repository testing utilities
    ├── database-helpers.ts           # SQLite database test helpers
    └── blazor-helpers.ts             # Blazor Server specific helpers
```

**Key Test Areas:**
- **Home Page**: Movie list loading from database, error states, data display
- **Repository Layer**: CRUD operations testing (`MoviesRepository`)
- **Database Integration**: SQLite database operations and Entity Framework Core
- **API Testing**: `/movies` endpoint validation and error handling  
- **Movie Data**: Title, genre, directors, rating, post-credits status (`Wait` field)
- **Error Scenarios**: Database connection failures, repository exceptions, API errors
- **Performance**: Database query performance and responsive design
- **Visual Regression**: UI consistency across browsers
- **Migration Testing**: Database schema migrations and data seeding

## Project Purpose

SneakPeek helps users find out if a movie has after-credits scenes, so you never miss extra content at the cinema.

---

Feel free to contribute or open issues for suggestions and bug reports.
