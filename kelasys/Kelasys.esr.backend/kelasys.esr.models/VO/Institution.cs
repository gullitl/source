using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace kelasys.esr.models.VO {
    public class Institution {
        [Key]
        public int Numero { get; set; }
        public string Nom { get; set; }
        public string Sigle { get; set; }
        public string Logo { get; set;  }
    }
}
