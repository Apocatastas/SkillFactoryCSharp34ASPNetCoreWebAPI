using HomeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly ILogger<DevicesController> _logger;

        public DevicesController(ILogger<DevicesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [HttpHead]
        [Route("{manufacturer}")]
        public IActionResult GetManual([FromRoute] string manufacturer) 
        {
            return StatusCode(200/*, $"Server name: {_options.Value.ServerName}"*/);
        }

    }
}
