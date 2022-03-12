using System.ComponentModel.DataAnnotations;

namespace JaarConsultTeste.Data.Dtos
{
    public class CreateVeiculoDto
    {
        [Required(ErrorMessage = "O código da tabela Fipe é obrigatório")]
        public string CodigoFipe { get; set; }

        [Required(ErrorMessage = "A placa do carro é obrigatória")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O ano é obrigatório")]
        public int Ano { get; set; }
    }
}
