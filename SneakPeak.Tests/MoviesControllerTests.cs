using Microsoft.AspNetCore.Mvc.Testing;

namespace SneakPeak.Tests
{
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
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}