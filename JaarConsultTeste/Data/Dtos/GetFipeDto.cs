using System.ComponentModel.DataAnnotations;

namespace JaarConsultTeste.Data.Dtos
{
    public class GetFipeDto
    {
        [Required]
        public string codigoFipe { get; set; }

        [Required]
        public int Ano { get; set; }
    }
}
