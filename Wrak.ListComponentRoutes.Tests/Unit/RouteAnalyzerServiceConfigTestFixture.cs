using Xunit;

namespace Wrak.ListComponentRoutes.Tests.Unit
{
    public class RouteAnalyzerServiceConfigTestFixture
    {
        [Fact]
        public void Sets_Default_Path()
        {
            var config = new RouteAnalyzerServiceConfig();
            Assert.Equal("/routes", config.Path);
        }
    }
}
