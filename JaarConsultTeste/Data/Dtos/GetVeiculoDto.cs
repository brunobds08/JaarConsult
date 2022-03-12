using System.ComponentModel.DataAnnotations;

namespace JaarConsultTeste.Data.Dtos
{
    public class GetVeiculoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public string CodigoFipe { get; set; }

        [Required]
        public int Ano { get; set; }
    }
}
