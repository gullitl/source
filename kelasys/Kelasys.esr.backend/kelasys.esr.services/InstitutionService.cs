using kelasys.esr.contrats;
using kelasys.esr.dbaccess;
using kelasys.esr.models.VO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kelasys.esr.services {
    public class InstitutionService : IInstitutionService {

        private ILogger<InstitutionService> Logger { get; }
        private AppDbContext Context { get; }

        public InstitutionService(ILogger<InstitutionService> logger) {
            Logger = logger;
            Context = AppDbContext.Instance;
        }

        public async Task<List<Institution>> GetAll() {
            return await Context.Institutions.ToListAsync();
        }

        public async Task<Institution> GetById(int id) {
            return await Context.Institutions.FindAsync(id);
        }

        public async Task<Institution> Create(Institution Institution) {
            Context.Institutions.Add(Institution);
            await Context.SaveChangesAsync();
            return Institution;
        }

        public async Task<bool> Update(Institution Institution) {
            Context.Entry(Institution).State = EntityState.Modified;

            try {
                await Context.SaveChangesAsync();
            } catch(DbUpdateConcurrencyException) {
                if(!IsInstitutionExiste(Institution.Numero)) {
                    return false;
                } else {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> Delete(int id) {
            Institution Institution = await Context.Institutions.FindAsync(id);
            if(Institution == null) {
                return false;
            }

            Context.Institutions.Remove(Institution);
            await Context.SaveChangesAsync();

            return true;
        }

        private bool IsInstitutionExiste(int numero) {
            return Context.Institutions.Any(u => u.Numero == numero);
        }

    }
}
