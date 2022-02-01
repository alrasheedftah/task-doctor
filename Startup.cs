using System.Text;
using ApiAppPetrol.Exceptions;
using ApiAppPetrol.Helpers;
using ApiAppPetrol.Models;
using ApiAppPetrol.Policies;
using ApiAppPetrol.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
// using OilCar.ALRASHID;
// using WebApplication1.Models;

namespace ApiAppPetrol
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
                // TODO  Update Server DataBases Connection 
   
        services.AddDbContext<DoctorDBContext>(
        options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
    );
   


            services.AddScoped<IDoctorServices,DoctorServices>();
            services.AddCors(cors => cors.AddPolicy("AllowCors", opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

        ///   Serrvices Application Debendancy Injection 
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter())
            );


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // app.UseExceptionHandler("/error");
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowCors");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization( 
            );
 // services.AddDbContext<PetrolTestsdContext>(
// using Microsoft.AspNetCore.HttpsPolicy;
    //     options => options.UseMySQL(Configuration.GetConnectionString("PetrolsdContextConnection"))
    // );

    // services.AddDbContext<PetrolUserSDContext>(
    //     options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"))
    // );
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
