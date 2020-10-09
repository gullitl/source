using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace kelasys.esr.models.VO {
    public class Utilisateur {
        [Key]
        public string NomUtilisateur { get; set; }
        public string MotDePasse { get; set; }
        public int MembreId { get; set; }
        public char Discriminator { get; set; }
    }
}
