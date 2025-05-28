using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AtlasMed_GS.Models
{
    [Table("TB_CONSULTA")]
    public class Consulta
    {

        [Key]
        public int IdConsulta { get; set; }

        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        public virtual Paciente? Paciente { get; set; }

        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
        public virtual Medico? Medico { get; set; }

        [ForeignKey("Prontuario")]
        public int IdProntuario { get; set; }
        public virtual Prontuario? Prontuario { get; set; }

        [ForeignKey("Hospital")]
        public int IdHospital { get; set; }
        public virtual Hospital? Hospital { get; set; }

        [ForeignKey("Medicacao")]

        public int IdMedicacao { get; set; }

        public virtual Medicacao? Medicacao { get; set; }


        [Required(ErrorMessage = "O horário de consulta é obrigatório!")]
        public DateTime HorarioConsulta { get; set; }

        [Required(ErrorMessage = "O diagnóstico é obrigatório!")]
        [StringLength(100, ErrorMessage = "O diagnóstico deve ter no máximo 100 caracteres")]
        public string Diagnostico;

    }
}
