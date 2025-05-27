using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AtlasMed_GS.Models
{
    [Table("TB_PACIENTE")]
    public class Paciente
    {

        [Key]
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório!")]
        [CustomValidation(typeof(CpfValidator), nameof(CpfValidator.IsValid))]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter apenas números, sem pontos e traços!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório!")]
        [Phone(ErrorMessage = "Número de telefone inválido!")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Telefone deve conter apenas números, sem parênteses e traços!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O número é obrigatório!")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório!")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório!")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP deve conter apenas números, sem traços!")]
        public string Cep { get; set; }
    }
}