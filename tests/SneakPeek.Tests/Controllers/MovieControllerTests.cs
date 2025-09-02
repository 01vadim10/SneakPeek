using Microsoft.EntityFrameworkCore;
using Moq;
using Domain.Interfaces;
using SneakPeek.Controllers;
using SneakPeek.Models;
using Microsoft.AspNetCore.Mvc;

namespace SneakPeek.Tests.Controllers;

public class MovieControllerTests
{
    [Fact]
    public async Task Get_ReturnsMovies_WhenMoviesExist()
    { 
        var mockRepo = new Mock<IMoviesRepository>();

        var movies = new List<Movie>
        {
            new Movie { Title = "God Of War" },
            new Movie { Title = "Star Wars"}
        };
        mockRepo.Setup(repo => repo.GetAllMoviesAsync())
            .ReturnsAsync(movies);

        var controller = new MoviesController(mockRepo.Object);

        var actionResult = await controller.Get();

        var okResult = Assert.IsType<OkObjectResult>(actionResult);
        var returnedValue = Assert.IsAssignableFrom<IEnumerable<Movie>>(okResult.Value);

        Assert.Equal(movies, returnedValue);
    }
}

