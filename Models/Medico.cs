using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AtlasMed_GS.Models
{
    [Table("TB_MEDICO1")]
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório!")]
        [CustomValidation(typeof(CpfValidator), nameof(CpfValidator.IsValid))]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter apenas números, sem pontos e traços!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O CRM é obrigatório!")]
        [StringLength(20, ErrorMessage = "O CRM deve ter no máximo 20 caracteres")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "CRM deve conter apenas números, sem pontos e traços!")]
        public string Crm { get; set; }

        [Required(ErrorMessage = "UF do CRM é obrigatória!")]
        [StringLength(2, ErrorMessage = "UF deve conter 2 caracteres")]
        [RegularExpression(@"^(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)$",
        ErrorMessage = "UF inválida")]
        public string UfCrm { get; set; }
        
        [Required(ErrorMessage = "A especialidade é obrigatória!")]
        [StringLength(100, ErrorMessage = "A especialidade deve ter no máximo 100 caracteres")]
        public string Especialidade { get; set; }
        public int IdHospital { get; set; }

        [ForeignKey("IdHospital")]
        public Hospital Hospital { get; set; }

    }
}
