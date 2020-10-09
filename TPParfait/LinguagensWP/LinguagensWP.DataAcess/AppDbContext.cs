using Asp.LinguagensWP.Models;
using Microsoft.EntityFrameworkCore;

namespace LinguagensWP.DataAccess {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions options) : base(options) {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Linguagem>()
                .HasOne(b => b.Autor)
                .WithMany(a => a.Linguagens);
        }

        public virtual DbSet<Linguagem> Linguagens { get; set; }
        public DbSet<Autor> Autores { get; set; }

    }
}
