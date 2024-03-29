﻿using ApiRest.Net.Business;
using ApiRest.Net.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;
/*
 * Esquema Model Business Controller
 * Controller => IBusiness => IRepository + Context
 */
namespace ApiRest.Net.Controllers
{   /*Na controller acessa-se a IBUSINESS*/
    /*Informações definidas para expor a API na URL*/
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}/books")]
    public class BooksController : ControllerBase
    {
        private IBooksBusiness _books;
        private readonly ILogger<BooksController> _log; //logs nao podem ser modificados
                                    //readonly ajuda na segurança
        public BooksController(ILogger<BooksController> logger, IBooksBusiness books) 
        {
            _log = logger;
            _books = books;
            //Adicionar o logger e o BooksBusiness para acessar os métodos
        }
        /*
            Implementar versão, rota e métodos da bookscontroller
        Toda api tem:
        1) Versão com ApiVersion
        2) Controller definition com ApiController
        3) Rota definida por Route() e cada atriuto direcionado
            por {nomeAtributo}

        4)e ela herda a controllerBase do próprio AspNetCore.MvC sem suporte para view (ja que se trata de API)
            Arquitetura model view controler baseado em camada
        5)Possui os verbos
            GET POST PUT DELETE            
         */
        [HttpGet()] //Para o findAll
        public IActionResult Get() {
            return Ok(_books.findAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            return Ok(_books.findByID(id)); //Deve-se retornar o Ok status.
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Books book) {
            return Ok(_books.create(book));
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Books book)
        {
            if (book == null) return BadRequest();
            return Ok(_books.update(book));
        }

        [HttpDelete()]
        public IActionResult Delete(int id) 
        {
            _books.delete(id);
            return NoContent();
        }




    }
}
