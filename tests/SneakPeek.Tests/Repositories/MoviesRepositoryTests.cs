using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Persistence;
using SneakPeek.Models;

namespace SneakPeak.Tests.Repositories;

public class MoviesRepositoryTests
{
    private DataContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

        var context = new DataContext(options);

        return new DataContext(options);
    }

    [Fact]
    public async Task GetAllMoviesAsync_ReturnsAllMovies()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Movies.AddRange(new Movie { Title = "Movie 1" }, new Movie { Title = "Movie 2" });
        await context.SaveChangesAsync();

        var repo = new MoviesRepository(context);

        // Act
        var result = await repo.GetAllMoviesAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, m => m.Title == "Movie 1");
        Assert.Contains(result, m => m.Title == "Movie 2");
    }

    [Fact]
    public async Task GetMovieByIdAsync_ReturnsCorrectMovie_WhenMovieExists()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Movies.Add(new Movie { Id = 1 , Title = "Test Movie" });
        await context.SaveChangesAsync();

        var repo = new MoviesRepository(context);

        // Act
        var result = await repo.GetMovieByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Test Movie", result.Title);
    }

    [Fact]
    public async Task GetMovieByIdAsync_ReturnsNull_WhenMovieDoesNotExist()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Movies.Add(new Movie { Id = 1, Title = "Test Movie" });
        await context.SaveChangesAsync();

        var repo = new MoviesRepository(context);

        // Act
        var result = await repo.GetMovieByIdAsync(99);

        // Assert
        Assert.Equal(null, result);
    }

    [Fact]
    public async Task AddMovieAsync_AddsMovieToDatabase()
    {
        // Arrange
        var context = GetInMemoryDbContext();

        var repo = new MoviesRepository(context);

        // Act
        await repo.AddMovieAsync(new Movie { Id = 1, Title = "Test"});

        // Assert
        Assert.Contains(context.Movies, m => m.Id == 1);
        Assert.Contains(context.Movies, m => m.Title == "Test");
    }

    [Fact]
    public async Task UpdateMovieAsync_UpdatesMovieProperties()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Movies.Add(new Movie { Id = 1, Title = "Test Movie" });
        await context.SaveChangesAsync();

        var repo = new MoviesRepository(context);

        // Act
        await repo.UpdateMovieAsync(new Movie { Id = 1, Title = "Test" });

        // Assert
        var updatedMovie = await context.Movies.FindAsync(1);
        Assert.NotNull(updatedMovie);
        Assert.Equal("Test", updatedMovie.Title);
    }
}

