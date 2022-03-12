using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaarConsultTeste.Model
{
    public class Veiculo
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CodigoFipe { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public int Ano { get; set; }
    }
}
