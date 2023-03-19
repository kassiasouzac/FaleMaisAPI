using FaleMaisAPI.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Xml;

namespace FaleMaisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {

        private readonly ICalculoService _service;
        public CalculadoraController(ICalculoService service)
        {
            _service = service;
        }

        
        [HttpPost]
        public ActionResult CalcularValorLigacao(string dddOrigem, string dddDestino, int minutos, int planoId)
        {

            var valorSemPlano = _service.Calcular(dddOrigem, dddDestino, minutos);
            var valorComPlano = _service.CalcularComPlano(dddOrigem, dddDestino, minutos, planoId);

            return Ok(new { valorComPlano, valorSemPlano });

        }

        
        [HttpGet("/api/calculadora/planos")]
  
        public ActionResult ListarPlanos()
        {

            var lista =_service.GetPlanos();

           
            return Ok(lista);
        }

        
        [HttpGet("/api/calculadora/ddds")]
        public ActionResult ListarDDD()
        {
            var lista = _service.GetDDD();

           
            return Ok(lista);
        }


    }
}
