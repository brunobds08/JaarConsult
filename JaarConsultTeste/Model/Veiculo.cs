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

        [Required(ErrorMessage ="A placa do carro é obrigatória")]
        public string Placa { get; set; }
    }
}
