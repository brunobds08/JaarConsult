using JaarConsultTeste.Data.Dtos;
using JaarConsultTeste.Services;
using Microsoft.AspNetCore.Mvc;

namespace JaarConsultTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FipeController : ControllerBase
    {
        private FipeService _fipeService;

        public FipeController(FipeService fipeService)
        {
            _fipeService = fipeService;
        }

        [HttpPost]
        [Route("ConsultaFipe")]
        public async Task<IActionResult> ConsultaFipe([FromBody] ConsultaFipeDto fipeDto)
        {
            var fipe = await _fipeService.ConsultaFipePorAno(fipeDto);

            if (fipe != null)
            {
                return Ok(fipe);
            }
            return NoContent();
        }

        [HttpPost]
        [Route("AdicionaVeiculo")]
        public async Task<IActionResult> AdicionaVeiculo([FromBody] CreateVeiculoDto createDto)
        {
            GetVeiculoDto veiculoDto = await _fipeService.AdicionaVeiculo(createDto);

            return CreatedAtAction(
                nameof(RecuperaVeiculoPorPlaca), 
                new { placa = veiculoDto.Placa }, 
                veiculoDto);
        }

        [HttpGet("{placa}")]
        public async Task<IActionResult> RecuperaVeiculoPorPlaca(string placa)
        {
            var veiculoDto = await _fipeService.RecuperaVeiculo(placa);

            if (veiculoDto != null)
            {
                return Ok(veiculoDto);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
