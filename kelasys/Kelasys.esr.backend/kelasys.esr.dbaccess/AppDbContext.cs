using kelasys.esr.models.VO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace kelasys.esr.dbaccess {
    public class AppDbContext : DbContext {

        #region DbContext configurations
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static AppDbContext() {
        }

        private AppDbContext() {
            Database.EnsureCreated();
            Database.Migrate();
        }

        public static AppDbContext Instance { get; } = new AppDbContext();

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseMySql("Server=127.0.0.1; port=3306; Database=kelasysesrdb; uid=root; password=#Fp31314");
            base.OnConfiguring(options);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }

        
        #endregion

        public virtual DbSet<Professeur> Professeurs { get; set; }
        public virtual DbSet<Eleve> Eleves { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    }
}
