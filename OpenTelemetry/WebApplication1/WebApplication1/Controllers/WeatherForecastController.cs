using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly ActivitySource MyActivitySource = new("MyActivitySource");

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Clusters/{clusterId}", Name = "AddCluster")]
        public async Task<Guid> AddCluster(string clusterId)
        {
            Console.WriteLine($"Add cluster {clusterId}.");
            return Guid.NewGuid();
        }
    }
}