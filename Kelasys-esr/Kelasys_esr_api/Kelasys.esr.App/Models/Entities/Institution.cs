using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelasys.esr.App.Models.Entities {
    [Table("institution")]
    public class Institution : EntityBase {
        public string Nom { get; set; }
        public string Sigle { get; set; }
        public string Logo { get; set; }
    }
}
