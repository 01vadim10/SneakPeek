using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Persistence;
using SneakPeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SneakPeek.Tests.Repositories
{
    public class MoviesRepositoryTests
    {
        private DataContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

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
    }
}