using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedeSocial.WebApp.Areas.Identity.Data;

namespace RedeSocial.WebApp.Data
{
    public class RedeSocialWebAppContext : IdentityDbContext<PerfilUsuario>
    {
        public RedeSocialWebAppContext(DbContextOptions<RedeSocialWebAppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
