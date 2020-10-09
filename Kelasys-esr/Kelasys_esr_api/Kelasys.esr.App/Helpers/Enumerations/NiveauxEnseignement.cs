using System.ComponentModel;

namespace Kelasys.esr.App.Helpers.Enumerations {
    public enum NiveauxEnseignement {
        [Description("Maternel")] Maternel = 1,
        [Description("Primaire")] Primaire = 2, 
        [Description("Secondaire")] Secondaire = 3
    }
}
