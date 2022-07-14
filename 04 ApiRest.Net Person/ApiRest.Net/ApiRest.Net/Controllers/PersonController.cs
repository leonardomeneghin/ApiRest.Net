using ApiRest.Net.Model;
using ApiRest.Net.services.implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Net.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //prefix para todos os endPoints dos controllers
    public class PersonController : ControllerBase
    {
        

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService; //Vai para a implementação da interface, no caso dentro da service

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
            
        }
        /*Lembre-se que na maturação das apis REST, o próprio contexto do rest consegue separar os path
         por método de request, entao não é necessário haver um path para cada método distinto, apenas
        para métodos similares (vários GET)*/
        /*Este Get é para listagem geral, então não possui path especificado.*/
        [HttpGet()]               //Caminho especifico do HTTP get
                                        //Bind ocorre entre {id} do path e 
        public IActionResult Get()
        {
            
            return Ok(_personService.findAll());
        
            
        }
        /*Este get possui path, ja que a busca é por ID. Além disso, se não encontrar nada, lembrar de retornar
            NOTFOUND
        */
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.findByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        
            
        }
        /*Aqui temos um método POST, vai enviar uma adição ao banco.
         * Se caso a requisição POST for vazia, lembrar de retornar
         * BADREQUEST
         */
        [HttpPost]               //Caminho especifico do HTTP get
                                        //Bind ocorre entre `{id} do path e 
        public IActionResult Post([FromBody] Person person) 
        {
            if (person == null) return BadRequest();
            return Ok(_personService.create(person));
        
        }
        [HttpPut]
        /*Aqui temos um método PUT (update)
         * Realizado através do path put, caso não for inseridos parâmetros para atualizar, lembrar de retornar BADREQUEST
         */
        public IActionResult Put([FromBody] Person person) 
        {
            if (person == null) return BadRequest();
            return Ok(_personService.update(person));

        }
        [HttpDelete("{id}")]//Precisa de parâmetro no path para deletarmos uma id conhecida.
        public IActionResult Delete(long id)
        {
            _personService.delete(id);
            return NoContent();


        }

    }
}
