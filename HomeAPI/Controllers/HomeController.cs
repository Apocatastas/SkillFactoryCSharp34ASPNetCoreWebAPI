using AutoMapper;
using HomeApi.Configuration;
using HomeAPI.Contracts.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;

namespace HomeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        public HomeController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        [HttpGet] 
        [Route("info")] 
        public IActionResult Info()
        {
            var infoResponse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);
            return StatusCode(200, infoResponse);
        }
    }
}
