
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelasys.esr.App.Models.Entities {
    [Table("professeur")]
    public class Professeur : Membre {
        
        public string TitreFormation { get; set; }


    }
}
