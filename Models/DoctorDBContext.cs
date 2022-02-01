using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiAppPetrol.Models
{
    public class DoctorDBContext : IdentityDbContext<ApplicationUser>
    {
        public DoctorDBContext(DbContextOptions<DoctorDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> doctors { get; set; }
        public DbSet<DoctorSchedual> DoctorScheduals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

}