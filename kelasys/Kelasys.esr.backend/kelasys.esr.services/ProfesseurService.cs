using kelasys.esr.contrats;
using kelasys.esr.dbaccess;
using kelasys.esr.models.VO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kelasys.esr.services {
    public class ProfesseurService : IProfesseurService {

        private ILogger<ProfesseurService> Logger { get; }
        private AppDbContext Context { get; }

        public ProfesseurService(ILogger<ProfesseurService> logger) {
            Logger = logger;
            Context = AppDbContext.Instance;
        }

        public async Task<List<Professeur>> GetAll() {
            return await Context.Professeurs.ToListAsync();
        }

        public async Task<Professeur> GetById(int id) {
            return await Context.Professeurs.FindAsync(id);
        }

        public async Task<Professeur> Create(Professeur professeur) {

            Professeur p = new Professeur {
                Id = 4,
                Nom = "Luzolo",
                Postnom = "Lusembo",
                Prenom = "Plamedi",
                Email = "plam.l@live.fr",
                TitreFormation = "Informaticien"
            };

            Eleve e = new Eleve {
                Id = 45,
                Nom = "Luzolo",
                Postnom = "Matanu",
                Prenom = "Hervé",
                Email = "hlm@live.fr",
                AnneeScolaire = "4e SC"

            };


            Utilisateur u = new Utilisateur {
                NomUtilisateur = "hm.l@gst.edu",
                MotDePasse = "jkhfdb",
                MembreId = p.Id,
                Discriminator = 'P'
            };

            Context.Set<Utilisateur>().Add(u);
            Context.Set<Professeur>().Add(p);
            await Context.SaveChangesAsync();
            return professeur;
        }





        public async Task<bool> Update(Professeur professeur) {
            Context.Entry(professeur).State = EntityState.Modified;

            try {
                await Context.SaveChangesAsync();
            } catch(DbUpdateConcurrencyException) {
                if(!await IsProfesseurExiste(professeur.Id)) {
                    return false;
                } else {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> Delete(int id) {
            Professeur Professeur = await Context.Professeurs.FindAsync(id);
            if(Professeur == null) {
                return false;
            }

            Context.Professeurs.Remove(Professeur);
            await Context.SaveChangesAsync();

            return true;
        }

        private async Task<bool> IsProfesseurExiste(int id) {
            return await Context.Professeurs.AnyAsync(p => p.Id == id);
        }
    }
}
