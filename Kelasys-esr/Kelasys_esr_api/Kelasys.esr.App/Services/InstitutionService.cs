
using Kelasys.esr.App.Contracts;
using Kelasys.esr.App.DataAccess.Contexts;
using Kelasys.esr.App.Models.Entities;

namespace Kelasys.esr.App.Services {
    public class InstitutionService : CrudService<Institution>, IInstitutionService {
        public InstitutionService(AppDbContext context) : base(context) {
        }
    }
}
