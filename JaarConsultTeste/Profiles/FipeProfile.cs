using AutoMapper;
using JaarConsultTeste.Data.Dtos;
using JaarConsultTeste.Model;

namespace JaarConsultTeste.Profiles
{
    public class FipeProfile : Profile
    {
        public FipeProfile()
        {
            CreateMap<CreateVeiculoDto, Veiculo>();
            CreateMap<ReadFipeDto, ReadVeiculoDto>();
            CreateMap<Veiculo, GetVeiculoDto>();

        }
    }
}
