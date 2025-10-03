using Microsoft.EntityFrameworkCore;
using Persistence;
using SneakPeek.Models;

namespace SneakPeak.Tests.Persistence;

public class DataContextSeedTests
{
    private DataContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new DataContext(options);
    }

    [Fact]
    public void Seed_PopulatesEmptyDatabase_WithFiveMovies()
    {
        // Arrange
        var context = GetInMemoryDbContext();

        // Act
        DataContext.Seed(context);

        // Assert
        Assert.Equal(5, context.Movies.Count());
        Assert.Contains(context.Movies, m => m.Title == "Inception");
        Assert.Contains(context.Movies, m => m.Title == "The Matrix");
        Assert.Contains(context.Movies, m => m.Title == "Parasite");
        Assert.Contains(context.Movies, m => m.Title == "Interstellar");
        Assert.Contains(context.Movies, m => m.Title == "The Godfather");
    }

    [Fact]
    public void Seed_IsIdempotent_DoesNotDuplicateRecords()
    {
        // Arrange
        var context = GetInMemoryDbContext();

        // Act
        DataContext.Seed(context);
        DataContext.Seed(context); // Call seed twice

        // Assert
        Assert.Equal(5, context.Movies.Count()); // Should still be 5, not 10
    }

    [Fact]
    public void Seed_PopulatesAllMovieProperties_Correctly()
    {
        // Arrange
        var context = GetInMemoryDbContext();

        // Act
        DataContext.Seed(context);

        // Assert - verify Inception movie properties
        var inception = context.Movies.FirstOrDefault(m => m.Title == "Inception");
        Assert.NotNull(inception);
        Assert.Equal("no wait", inception.Wait);
        Assert.Equal("A skilled thief, the absolute best in the dangerous art of extraction, steals valuable secrets from deep within the subconscious during the dream state.", inception.Description);
        Assert.Equal("2010-07-16", inception.Release_date);
        Assert.Equal("Science Fiction", inception.Genre);
        Assert.Single(inception.Directors);
        Assert.Contains("Christopher Nolan", inception.Directors);
        Assert.Equal(8.8, inception.Rating);

        // Assert - verify Parasite movie (has "wait")
        var parasite = context.Movies.FirstOrDefault(m => m.Title == "Parasite");
        Assert.NotNull(parasite);
        Assert.Equal("wait", parasite.Wait);
        Assert.Equal("2019-05-30", parasite.Release_date);
        Assert.Single(parasite.Directors);
        Assert.Contains("Bong Joon-ho", parasite.Directors);
        Assert.Equal(8.6, parasite.Rating);

        // Assert - verify The Matrix movie (multiple directors)
        var matrix = context.Movies.FirstOrDefault(m => m.Title == "The Matrix");
        Assert.NotNull(matrix);
        Assert.Equal(2, matrix.Directors.Count);
        Assert.Contains("Lana Wachowski", matrix.Directors);
        Assert.Contains("Lilly Wachowski", matrix.Directors);
        Assert.Equal(8.7, matrix.Rating);
    }

    [Fact]
    public void Seed_DoesNotAddMovies_WhenDatabaseIsNotEmpty()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Movies.Add(new Movie { Title = "Existing Movie" });
        context.SaveChanges();

        // Act
        DataContext.Seed(context);

        // Assert
        Assert.Single(context.Movies); // Should still be 1, not 6
        Assert.Contains(context.Movies, m => m.Title == "Existing Movie");
        Assert.DoesNotContain(context.Movies, m => m.Title == "Inception");
    }
}
