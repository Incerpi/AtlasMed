using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AtlasMed_GS.Models
{
    [Table("TB_MEDICACAO")]

    public class Medicacao
    {

        [Key]
        public int IdMedicacao { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória!")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O principio ativo é obrigatório!")]
        [StringLength(100, ErrorMessage = "O principio ativo deve ter no máximo 100 caracteres")]
        public string PrincipioAtivo { get; set; }

        [Required(ErrorMessage = "A dose é obrigatória!")]
        [StringLength(100, ErrorMessage = "A dose deve ter no máximo 100 caracteres")]
        public string Dose { get; set; }

        [Required(ErrorMessage = "A dosagem é obrigatória!")]
        [StringLength(100, ErrorMessage = "A dosagem deve ter no máximo 100 caracteres")]
        public string Dosagem { get; set; }
    }
}
