using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AtlasMed_GS.Models
{
    [Table("TB_PRONTUARIO")]
    public class Prontuario
    {
        [Key]
        public int IdProntuario { get; set; }

        [Required(ErrorMessage = "O horário de chegada é obrigatório!")]
        public DateTime HorarioChegada { get; set; }

        [Required(ErrorMessage = "Os sintomas são obrigatórios!")]
        [StringLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres")]
        public string Sintomas { get; set; }

        [Required(ErrorMessage = "Alergias são obrigatórias!")]
        [StringLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres")]
        public string Alergias { get; set; }

        [Required(ErrorMessage = "O tipo sanguíneo é obrigatório!")]
        [StringLength(100, ErrorMessage = "O tipo sanguíneo deve ter no máximo 3 caracteres")]
        public string TipoSanguineo { get; set; }


        [Required]

        public int IdPaciente { get; set; }

        [ForeignKey("IdPaciente")]

        public Paciente Paciente { get; set; }


    }
}
