using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ApiRest.Net.Controllers
{
    [ApiVersion("1")] //Comes from AspNetCore.Mvc
    [ApiController]
    [Route("/api/[controller]/v{version:apiVersion}")]
    public class PlayerDataController : ControllerBase
    {
        private ILogger<PlayerDataController> _logger;
        public PlayerDataController(ILogger<PlayerDataController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }


        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }


        [HttpDelete]
        public IActionResult Delete()
        {
            return NoContent();
        }
    }
}

