using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedeSocial.WebApp.Areas.Identity.Data;
using RedeSocial.WebApp.Data;

[assembly: HostingStartup(typeof(RedeSocial.WebApp.Areas.Identity.IdentityHostingStartup))]
namespace RedeSocial.WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RedeSocialWebAppContext>(options =>
                    options.UseMySQL(
                        context.Configuration.GetConnectionString("RedeSocialWebAppContextConnection")));

                services.AddDefaultIdentity<PerfilUsuario>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<RedeSocialWebAppContext>();
            });
        }
    }
}