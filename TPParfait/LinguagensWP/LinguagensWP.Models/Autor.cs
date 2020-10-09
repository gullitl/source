using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Asp.LinguagensWP.Models
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }
        
        [Required(ErrorMessage ="Campo Nome Completo obrigatório.")]
        [DisplayName("Nome Completo")]
        public string NomeCompleto { get; set; }
        
        public List<Linguagem>Linguagens { get; set; }
        
        [Required(ErrorMessage = "Campo Data Nascimento obrigatório.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo Ativo obrigatório.")]
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
    }
}
