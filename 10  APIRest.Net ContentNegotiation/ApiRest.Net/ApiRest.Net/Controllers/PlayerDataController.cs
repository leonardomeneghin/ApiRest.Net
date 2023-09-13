using ApiRest.Net.Business;
using ApiRest.Net.Model;
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
        private IPlayerDataBusiness _dataPlayerBusiness;
        public PlayerDataController(ILogger<PlayerDataController> logger, IPlayerDataBusiness playerData)
        {
            _logger = logger;
            _dataPlayerBusiness = playerData;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var players = _dataPlayerBusiness.FindAll();
            if (players is null) return NotFound();
            return Ok(players);
        }


        [HttpPost]
        public IActionResult Create([FromBody] PlayerData player )
        {
            if (player == null) return BadRequest("Parâmetros incorretos, verifique os valores que estão sendo enviados.");
            return Ok(_dataPlayerBusiness.Create(player));
        }

        [HttpPut]
        public IActionResult Update([FromBody] PlayerData player)
        {
            return Ok(_dataPlayerBusiness.Update(player));
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _dataPlayerBusiness.Delete(id);
            return NoContent();
        }
    }
}

