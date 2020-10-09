using Kelasys.esr.App.Contracts;
using Kelasys.esr.App.DataAccess.Contexts;
using Kelasys.esr.App.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kelasys.esr.AppStartup {
    public class Startup {
        private static readonly string _corsPolicyName = "Cors:PolicyName";
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            
            services.AddCors(options => {
                options.AddPolicy(Configuration[_corsPolicyName],
                                  builder => builder.WithOrigins(Configuration["Cors:ConfiguePolicy:Origins"])
                                                    .AllowCredentials()
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader());
            });
            services.AddDbContext<AppDbContext>(options =>
                                                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProfesseurService, ProfesseurService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(Configuration[_corsPolicyName]);

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
