using AutoMapper;
using JaarConsultTeste.Data;
using JaarConsultTeste.Data.Dtos;
using JaarConsultTeste.Model;

namespace JaarConsultTeste.Services
{
    public class FipeService
    {
        AppDbContext _context;
        IMapper _mapper;
        BrasilAPIService _clientService;

        public FipeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            _clientService = new BrasilAPIService();
        }

        public async Task<ReadFipeDto> ConsultaFipePorAno(ConsultaFipeDto consultaFipeDto)
        {
            var readFipeDto = await _clientService.RecuperaDadosPorFipe(consultaFipeDto.CodigoFipe);

            return readFipeDto.FirstOrDefault(f => f.AnoModelo == consultaFipeDto.Ano);
        }

        public async Task<GetVeiculoDto> AdicionaVeiculo(CreateVeiculoDto veiculoDto)
        {
            Veiculo veiculo = _mapper.Map<Veiculo>(veiculoDto);
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();

            return _mapper.Map<GetVeiculoDto>(veiculo);
        }

        public async Task<ReadVeiculoDto> RecuperaVeiculo(string placa)
        {
            var veiculo = _context.Veiculos.FirstOrDefault(v => v.Placa == placa);

            if (veiculo != null)
            {
                ReadVeiculoDto readVeiculoDto = new ReadVeiculoDto();
                var dadosFipeVeiculo = await _clientService.RecuperaDadosPorFipe(veiculo.CodigoFipe);

                _mapper.Map(dadosFipeVeiculo.FirstOrDefault(v => v.AnoModelo == veiculo.Ano), 
                    readVeiculoDto);
                readVeiculoDto.Placa = placa;
                readVeiculoDto.Id = veiculo.Id;

                return readVeiculoDto;
            }

            return null;
        }
    }
}
