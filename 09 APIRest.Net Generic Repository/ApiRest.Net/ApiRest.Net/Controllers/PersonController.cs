using ApiRest.Net.Business.implementations;
using ApiRest.Net.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiRest.Net.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")] //Versionamento da controller
    public class PersonController : ControllerBase
    {
        

        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personService)
        {
            _logger = logger;
            _personBusiness = personService;
            
        }
        /*Lembre-se que na maturação das apis REST, o próprio contexto do rest consegue separar os path
         por método de request, entao não é necessário haver um path para cada método distinto, apenas
        para métodos similares (vários GET)*/
        /*Este Get é para listagem geral, então não possui path especificado.*/
        [HttpGet()]               //Caminho especifico do HTTP get
                                        //Bind ocorre entre {id} do path e 
        public IActionResult Get()
        {
            
            return Ok(_personBusiness.FindAll());
        
            
        }
        /*Este get possui path, ja que a busca é por ID. Além disso, se não encontrar nada, lembrar de retornar
            NOTFOUND
        */
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
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
            return Ok(_personBusiness.Create(person));
        
        }
        [HttpPut]
        /*Aqui temos um método PUT (update)
         * Realizado através do path put, caso não for inseridos parâmetros para atualizar, lembrar de retornar BADREQUEST
         */
        public IActionResult Put([FromBody] Person person) 
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));

        }
        [HttpDelete("{id}")]//Precisa de parâmetro no path para deletarmos uma id conhecida.
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();


        }

    }
}
