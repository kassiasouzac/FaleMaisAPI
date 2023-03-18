using FaleMaisAPI.Interfaces;
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
        public ActionResult CalcularValorLigacao(string dddOrigem, string dddDestino, int minutos, int planoId)
        {

            var valorSemPlano = _service.Calcular(dddOrigem, dddDestino, minutos);
            var valorComPlano = _service.CalcularComPlano(dddOrigem, dddDestino, minutos, planoId);

            return Ok(new { valorComPlano, valorSemPlano });

        }


    }
}
