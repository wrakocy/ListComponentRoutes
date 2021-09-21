using System.Threading.Tasks;
using Wrak.ListComponentRoutes.Tests.WebApp;
using Xunit;

namespace Wrak.ListComponentRoutes.Tests.Functional
{
    public class Middleware
    {
        [Fact]
        public async Task Returns_Default_Content()
        {
            // Arrange
            var factory = new CustomWebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/counter");

            // Assert
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("<h1>Counter</h1>", stringResponse);
        }

        [Theory]
        [InlineData("/routes")]
        [InlineData("/custom-route")]
        public async Task Returns_Middleware_Content(string path)
        {
            // Arrange
            var factory = new CustomWebApplicationFactory<Startup> { Path = path };
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync(path);

            // Assert
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("<h1>Component Routes</h1>", stringResponse);
            Assert.Contains("<td style='width:20%;'>Index</td>", stringResponse);
            Assert.Contains("<td style='width:20%;'>Counter</td>", stringResponse);
            Assert.Contains("<td style='width:20%;'>FetchData</td>", stringResponse);
        }
    }
}