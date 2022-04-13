using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace Boilerplate.WebApi.Tests.Integration
{
    public class ApiHealthTests : IClassFixture<TestFixture<Program>>
    {
        private readonly HttpClient _httpClient;

        public ApiHealthTests(TestFixture<Program> factory) => _httpClient = factory.CreateClient();

        [Theory]
        [InlineData("api/health")]
        public async Task Should_Return_Status200(string url)
        {
            var resp = await _httpClient.GetAsync(url);
            
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }
    }
}
