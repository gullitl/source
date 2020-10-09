

namespace kelasys.esr.models.VO {
    public abstract class Membre {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Postnom { get; set; }
        public string Prenom { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }

    }
}
