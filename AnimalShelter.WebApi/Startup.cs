using AnimalShelter.Core.Repositories;
using AnimalShelter.Infrastructure.Repositories;
using AnimalShelter.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AnimalShelter.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IAnimalService, AnimalService>();

            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();

            services.AddScoped<IShelterBoxRepository, ShelterBoxRepository>();
            services.AddScoped<IShelterBoxService, ShelterBoxService>();

            services.AddScoped<IMedicalProcedureRepository, MedicalProcedureRepository>();
            services.AddScoped<IMedicalProcedureService, MedicalProcedureService>();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 16;
                options.User.RequireUniqueEmail = true;
            });

            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("AnimalShelterConnectionString"),
                    b => b.MigrationsAssembly("AnimalShelter.WebApi")
                )
            );

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = "http://localhost:5000",
                        ValidIssuer = "http://localhost:5000",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("y5&LCz#,p9kk!8B/"))
                    };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
