
using Kelasys.esr.App.Helpers.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelasys.esr.App.Models.Entities {
    [Table("eleve")]
    public class Eleve : Membre {
        
        public AnneeEnseignement AnneeEnseignement { get; set; }

        public NiveauxEnseignement NiveauxEnseignement { get; set; }

        public AnneeScolaire AnneeScolaire { get; set; }
    }
}
