using System.ComponentModel.DataAnnotations;

namespace JaarConsultTeste.Data.Dtos
{
    public class ConsultaFipeDto
    {
        [Required]
        public string CodigoFipe { get; set; }

        [Required]
        public int Ano { get; set; }
    }
}
