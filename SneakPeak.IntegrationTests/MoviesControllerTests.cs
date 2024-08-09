using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Net;

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
            //Arrange
            const string url = "/movies";
            var client = _factory.CreateClient();

           //Act
            var response = await client.GetAsync(url);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }
    }
}
