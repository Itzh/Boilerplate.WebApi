using Boilerplate.WebApi.Endpoints.Health;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Boilerplate.WebApi.Tests.Endpoints.Health
{
    public class GetTests
    {
        ILogger<Get> logger = A.Fake<ILogger<Get>>();
        
        [Fact]
        public async Task HealthApiEndpoint()
        {
            var healthEndpoint = new Get(logger);

            var res = await healthEndpoint.HandleAsync();

            Assert.NotEmpty(res.Value);
            Assert.IsType<String>(res.Value);
        }
    }
}
