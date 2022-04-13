using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebApi.Endpoints.Health
{
    public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<String>
    {
        private readonly ILogger<Get> _logger;
        public Get(ILogger<Get> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Health check endpoint
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Current UTC DateTime</returns>
        [HttpGet("api/health")]
        public override async Task<ActionResult<string>> HandleAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogDebug("health check");
            return await Task.FromResult(DateTime.UtcNow.ToString());
        }
    }
}
