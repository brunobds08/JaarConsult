using System.ComponentModel.DataAnnotations;

namespace JaarConsultTeste.Data.Dtos
{
    public class ReadVeiculoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string CodigoFipe { get; set; }

        [Required(ErrorMessage = "A placa do carro é obrigatória")]
        public string Placa { get; set; }
    }
}
