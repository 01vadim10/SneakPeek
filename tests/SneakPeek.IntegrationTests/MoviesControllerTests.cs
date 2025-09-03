using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using SneakPeek.Models;
using FluentAssertions;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text.Json;

public class MovieControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public MovieControllerTest(WebApplicationFactory<Program> factory)
    { 
        _factory = factory;
    }

    [Fact]
    public async Task Get_WhenMoviesExist_ReturnsSuccessAndListOfMovies()
    { 
        var testMovies = new List<Movie>
        { 
            new Movie { Id = 1, Title = "Title 1"},
            new Movie { Id = 2, Title = "Title 2"}
        };

        var repoMock = new Mock<IMoviesRepository>();
        repoMock.Setup(r => r.GetAllMoviesAsync()).ReturnsAsync(testMovies);

        var client = _factory.WithWebHostBuilder(
            builder =>
            {
                builder.ConfigureServices(
                    services =>
                    {
                        var descriptor = services.SingleOrDefault(s => s.ServiceType == typeof(IMoviesRepository));
                        if (descriptor != null)
                        {
                            services.Remove(descriptor);
                        }
                        services.AddScoped<IMoviesRepository>(_=>repoMock.Object);
                    });
            }).CreateClient();

        const string url = "/movies";
        var response = await client.GetAsync(url);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        var moviesFromApi = JsonSerializer.Deserialize<List<Movie>>(json, options);

        moviesFromApi.Should().NotBeNull();
        moviesFromApi.Should().HaveCount(2);
        moviesFromApi.Should().BeEquivalentTo(testMovies);
    }
}