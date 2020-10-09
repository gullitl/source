using System.ComponentModel;

namespace Kelasys.esr.App.Helpers.Enumerations {
    public enum NiveauAcces {
        [Description("Administrateur")] Administrateur = 1,
        [Description("Utilisateur")] Utilisateur = 2
    }
}
