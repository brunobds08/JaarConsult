using AutoMapper;
using JaarConsultTeste.Data;
using JaarConsultTeste.Data.Dtos;

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

        public async Task<ReadFipeDto> ConsultaFipePorAno(GetFipeDto getFipeDto)
        {
            var readFipeDto = await _clientService.RecuperaDadosPorFipe(getFipeDto.codigoFipe);

            return readFipeDto.FirstOrDefault(f => f.AnoModelo == getFipeDto.Ano);
        }

        internal void AdicionaVeiculo(CreateFipeDto fipeDto)
        {
            throw new NotImplementedException();
        }

        internal ReadVeiculoDto RecuperaVeiculo(string placa)
        {
            throw new NotImplementedException();
        }
    }
}
