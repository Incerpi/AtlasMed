﻿using System.ComponentModel.DataAnnotations;

namespace AtlasMed_GS.Models
{
    public class Hospital
    {
        [Key]
        public int IdHospital { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Cep { get; set; }

    }
}

