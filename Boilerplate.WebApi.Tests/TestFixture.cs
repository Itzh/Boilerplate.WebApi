using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
namespace Boilerplate.WebApi.Tests
{
    public class TestFixture<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        private IWebHostBuilder _webHostBuilder;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            builder.ConfigureServices(services =>
            {
                // TODO: Add database instance for tests
            });
        }

        private void SetEnvironmentVariable(string var, string value)
        {
            Environment.SetEnvironmentVariable(var, value);
        }
    }
}
