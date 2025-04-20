using AutoMapper;
using HomeApi.Configuration;
using HomeAPI.Contracts.Devices;
using HomeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HomeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        public DevicesController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return StatusCode(200, "Устройства отсутствуют");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(
                                    [FromBody] 
                                    AddDeviceRequest request 
                                )
        {
            return StatusCode(200, $"Устройство {request.Name} добавлено!");
        }
    }
}
