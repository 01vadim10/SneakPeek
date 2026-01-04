using NSubstitute;
using Domain.Interfaces;
using SneakPeek.Controllers;
using SneakPeek.Models;
using Microsoft.AspNetCore.Mvc;
using Shouldly;

namespace SneakPeek.Tests.Controllers;

public class MoviesControllerTests
{
    [Fact]
    public async Task Get_ReturnsMovies_WhenMoviesExist()
    {
        // Arrange
        var mockRepo = Substitute.For<IMoviesRepository>();

        var movies = new List<Movie>
        {
            new Movie { Title = "God Of War" },
            new Movie { Title = "Star Wars"}
        };
        mockRepo.GetAllMoviesAsync().Returns(movies);

        var controller = new MoviesController(mockRepo);

        // Act
        var actionResult = await controller.Get();

        // Assert
        var okResult = actionResult.ShouldBeOfType<OkObjectResult>();
        var returnedValue = okResult.Value.ShouldBeOfType<List<Movie>>();
        returnedValue.ShouldBe(movies);
    }

    [Fact]
    public async Task Get_ReturnsNotFound_WhenRepositoryReturnsNull()
    {
        // Arrange
        var mockRepo = Substitute.For<IMoviesRepository>();
        mockRepo.GetAllMoviesAsync().Returns((List<Movie>?)null);
        var controller = new MoviesController(mockRepo);

        // Act
        var result = await controller.Get();

        // Assert
        var notFoundResult = result.ShouldBeOfType<NotFoundObjectResult>();
        notFoundResult.Value.ShouldBe("No movies found.");
    }

    [Fact]
    public async Task Get_ReturnsNotFound_WhenRepositoryReturnsEmptyList()
    {
        // Arrange
        var mockRepo = Substitute.For<IMoviesRepository>();
        mockRepo.GetAllMoviesAsync().Returns(new List<Movie>());
        var controller = new MoviesController(mockRepo);

        // Act
        var result = await controller.Get();

        // Assert
        var notFoundResult = result.ShouldBeOfType<NotFoundObjectResult>();
        notFoundResult.Value.ShouldBe("No movies found.");
    }
}

