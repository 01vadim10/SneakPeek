using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

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
            const string url = "/movies";
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/json; charset=utf-8",
            response.Content.Headers.ContentType.ToString());
        }
    }
}
