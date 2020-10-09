using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.LinguagensWP.Models
{
    public class Linguagem
    {
        [Key]
        public int LinguagemId { get; set; }
        
        [Required(ErrorMessage ="Campo Nome obrigatório.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        
        public Autor Autor { get; set; }

        [Required(ErrorMessage = "Campo Autor obrigatório.")]
        [ForeignKey("Autor")]
        [DisplayName("Autor")]
        public int AutorId { get; set; }
        
        [Required(ErrorMessage = "Campo Data Criação obrigatório.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Data Criação")]
        public DateTime DataCricao { get; set; }
        
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
