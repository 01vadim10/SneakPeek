using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using SneakPeek.Models;
using System.Net;
using System.Text.Json;

namespace SneakPeak.IntegrationTests;

public class MoviesControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public MoviesControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_MoviesEndpointsReturnSuccessAndCorrectContentType()
    {
        // Arrange
        const string url = "/movies";
        var client = _factory.CreateClient();

        //Act
        var response = await client.GetAsync(url);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Headers.ContentType?.ToString().Should().Be("application/json; charset=utf-8");

        var json = await response.Content.ReadAsStringAsync();
        var movies = JsonSerializer.Deserialize<List<Movie>>(json);

        movies.Should().NotBeNull();
        movies?.Count.Should().Be(5); // Should have exactly 5 seeded movies
    }

    [Fact]
    public async Task Get_MoviesEndpoint_ReturnsSeededMoviesWithCorrectData()
    {
        // Arrange
        const string url = "/movies";
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var json = await response.Content.ReadAsStringAsync();
        var movies = JsonSerializer.Deserialize<List<Movie>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        movies.Should().NotBeNull();
        movies.Should().HaveCount(5);

        // Verify specific seeded movies
        movies.Should().Contain(m => m.Title == "Inception" && m.Wait == "no wait" && m.Rating == 8.8);
        movies.Should().Contain(m => m.Title == "The Matrix" && m.Wait == "no wait" && m.Rating == 8.7);
        movies.Should().Contain(m => m.Title == "Parasite" && m.Wait == "wait" && m.Rating == 8.6);
        movies.Should().Contain(m => m.Title == "Interstellar" && m.Wait == "no wait" && m.Rating == 8.6);
        movies.Should().Contain(m => m.Title == "The Godfather" && m.Wait == "wait" && m.Rating == 9.2);

        // Verify a movie with multiple directors
        var matrix = movies?.FirstOrDefault(m => m.Title == "The Matrix");
        matrix.Should().NotBeNull();
        matrix?.Directors.Should().HaveCount(2);
        matrix?.Directors.Should().Contain("Lana Wachowski");
        matrix?.Directors.Should().Contain("Lilly Wachowski");
    }
}
