using JaarConsultTeste.Data.Dtos;
using JaarConsultTeste.Services;
using Microsoft.AspNetCore.Mvc;

namespace JaarConsultTeste.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class FipeController : ControllerBase
    {
        private FipeService _fipeService;

        public FipeController(FipeService fipeService)
        {
            _fipeService = fipeService;
        }

        [HttpPost]
        public IActionResult ConsultaFipePorAno([FromBody] ReadFipeDto fipeDto)
        {
            var fipe = _fipeService.ConsultaFipePorAno(fipeDto);
            return Ok(fipe);
        }

        [HttpPost]
        [Route("/AdicionarVeiculo")]
        public IActionResult AdicionaVeiculo([FromBody] CreateFipeDto fipeDto)
        {
            _fipeService.AdicionaVeiculo(fipeDto);

            return NoContent();
        }

        [HttpGet]
        public IActionResult RecuperaVeiculo([FromQuery] string placa)
        {
            var veiculoDto = _fipeService.RecuperaVeiculo(placa);

            return Ok(veiculoDto);
        }
    }
}
