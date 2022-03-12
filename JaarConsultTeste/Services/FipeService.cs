using AutoMapper;
using JaarConsultTeste.Data;
using JaarConsultTeste.Data.Dtos;

namespace JaarConsultTeste.Services
{
    public class FipeService
    {
        AppDbContext _context;
        IMapper _mapper;

        public FipeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        internal object ConsultaFipePorAno(ReadFipeDto fipeDto)
        {
            throw new NotImplementedException();
            // Consulta a ApiBrasil

            // filtra os dados por ano
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
