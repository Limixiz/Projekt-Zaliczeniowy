using Form_App.Models.DataBaseModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Form_App.ViewModels;
using Form_App.ViewModels.TherapyInfoViewModel;

namespace Form_App.Context
{
    public class Form_AppContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public Form_AppContext(DbContextOptions<Form_AppContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Therapy> Therapies { get; set; }

        
    }
}
