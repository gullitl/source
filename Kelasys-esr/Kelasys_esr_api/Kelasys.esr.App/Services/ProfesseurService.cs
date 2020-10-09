
using Kelasys.esr.App.Contracts;
using Kelasys.esr.App.DataAccess.Contexts;
using Kelasys.esr.App.Models.Entities;

namespace Kelasys.esr.App.Services {
    public class ProfesseurService : CrudService<Professeur>, IProfesseurService {
        public ProfesseurService(AppDbContext context) : base(context) {
        }
    }
}
