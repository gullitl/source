using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using RedeSocial.Domain;
using RedeSocial.Infraestrutura.EntityFramework.TypeConfigurations;
using Microsoft.EntityFrameworkCore.Design;

namespace RedeSocial.Infraestrutura.EntityFramework.Data
{
    public class DomainDbContext : DbContext
    {
        //Onde está o BD?
        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //Como é o BD?
        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //    modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new ComentarioEntityTypeConfiguration());
        //}

        public DbSet<Post> Posts { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
    }


}
