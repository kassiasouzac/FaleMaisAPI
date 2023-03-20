using FaleMaisAPI.Interfaces;
using FaleMaisAPI.Models;
using Microsoft.AspNetCore.Mvc;


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
        public ActionResult CalcularValorLigacao([FromBody] Dados dados)
        {


            var valorSemPlano = _service.Calcular(dados.dddOrigem, dados.dddDestino, dados.minutos);
            var valorComPlano = _service.CalcularComPlano(dados.dddOrigem, dados.dddDestino, dados.minutos, dados.planoId);

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
