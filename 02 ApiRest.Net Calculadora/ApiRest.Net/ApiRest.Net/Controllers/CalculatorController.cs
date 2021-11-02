using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{seccondNumber}")] //Caminho especifico do HTTP get
                                        //parametro1 faz bind com firstNumber, segundo campo faz Bind com segundo campo
        public IActionResult Sum(string operacao, string firstNumber, string seccondNumber)
        {
            //Verifica se numero é válido
           if (IsNumeric(firstNumber) && IsNumeric(seccondNumber)) 
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(seccondNumber);
                //retorna "ok" http status e mostra a soma como string.
                return Ok(sum.ToString());
            }
            //BadRequest se o valor não for válido
            return BadRequest("Invalid Input");
        }
        //Subtracao
        [HttpGet("sub/{firstNumber}/{seccondNumber}")] //Caminho especifico do HTTP get
                                                              //parametro1 faz bind com firstNumber, segundo campo faz Bind com segundo campo
        public IActionResult Subtraction(string operacao, string firstNumber, string seccondNumber)
        {
            //Verifica se numero é válido
            if (IsNumeric(firstNumber) && IsNumeric(seccondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(seccondNumber);
                //retorna "ok" http status e mostra a soma como string.
                return Ok(sum.ToString());
            }
            //BadRequest se o valor não for válido
            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{seccondNumber}")] //Caminho especifico do HTTP get
                                                              //parametro1 faz bind com firstNumber, segundo campo faz Bind com segundo campo
        public IActionResult Division(string operacao, string firstNumber, string seccondNumber)
        {
            //Verifica se numero é válido
            if (IsNumeric(firstNumber) && IsNumeric(seccondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(seccondNumber);
                //retorna "ok" http status e mostra a soma como string.
                return Ok(sum.ToString());
            }
            //BadRequest se o valor não for válido
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{seccondNumber}")] //Caminho especifico do HTTP get
                                                              //parametro1 faz bind com firstNumber, segundo campo faz Bind com segundo campo
        public IActionResult Multiplication(string operacao, string firstNumber, string seccondNumber)
        {
            //Verifica se numero é válido
            if (IsNumeric(firstNumber) && IsNumeric(seccondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(seccondNumber);
                //retorna "ok" http status e mostra a soma como string.
                return Ok(sum.ToString());
            }
            //BadRequest se o valor não for válido
            return BadRequest("Invalid Input");
        }

        [HttpGet("avarage/{firstNumber}/{seccondNumber}")] //Caminho especifico do HTTP get
                                                              //parametro1 faz bind com firstNumber, segundo campo faz Bind com segundo campo
        public IActionResult Get(string operacao, string firstNumber, string seccondNumber)
        {
            //Verifica se numero é válido
            if (IsNumeric(firstNumber) && IsNumeric(seccondNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(seccondNumber))/2;
                //retorna "ok" http status e mostra a soma como string.
                return Ok(sum.ToString());
            }
            //BadRequest se o valor não for válido
            return BadRequest("Invalid Input");
        }

        [HttpGet("square-root/{firstNumber}/{seccondNumber}")] //Caminho especifico do HTTP get
                                                              //parametro1 faz bind com firstNumber, segundo campo faz Bind com segundo campo
        public IActionResult Get(string operacao, string firstNumber)
        {
            //Verifica se numero é válido
            if (IsNumeric(firstNumber))
            {

                var sum = Math.Sqrt(((double)ConvertToDecimal(firstNumber)));
                //retorna "ok" http status e mostra a soma como string.
                return Ok(sum.ToString());
            }
            //BadRequest se o valor não for válido
            return BadRequest("Invalid Input");
        }
        private bool IsNumeric(string strNumber)
        {
            //TODO
            double number;
            //Faz a verificação se é numérico
            //Pram1: Obtem o estilo do numero (alguns paises usam , outros .)
            //Param2: Obtem informações culturais de formatação e conversão de números
            //Variável de saída 
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);

            return isNumber;
           
        }


        private decimal ConvertToDecimal(string strNumber)
        {//Converte os números para decimal
         //Instância de valor decimal para retornar
            decimal decimalValue;
            //verifica se a conversão funciona, se funcionar, a variável de será decimalValue que recebe o
                //TryParse
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
     
    }
}
