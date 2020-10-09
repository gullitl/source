﻿using LinguagensWP.Domain.AutorAggregate;
using LinguagensWP.Domain.LinguagemAggregate;
using Microsoft.EntityFrameworkCore;

namespace LinguagensWP.Infrastructure.DataAccess.Contexts
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreatedAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Linguagem>()
                .HasOne(b => b.Autor)
                .WithMany(a => a.Linguagens);
        }

        public virtual DbSet<Linguagem> Linguagens { get; set; }
        public DbSet<Autor> Autores { get; set; }

    }
}
