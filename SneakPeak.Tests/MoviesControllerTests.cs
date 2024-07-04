using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;

namespace SneakPeak.Tests
{
    public class MoviesControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public MoviesControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/movies")]
        public async Task Get_MoviesEndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
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