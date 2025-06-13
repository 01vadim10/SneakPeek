using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
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

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Headers.ContentType?.ToString().Should().Be("text/json; charset=utf-8");

        var json = await response.Content.ReadAsStringAsync();
        var movies = JsonSerializer.Deserialize<List<Movie>>(json);

        movies.Should().NotBeNull();
        movies?.Count.Should().BeGreaterThan(0);
    }
}
