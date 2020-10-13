using Form_App.Models.DataBaseModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Form_App.Context
{
    public class Form_AppContext : IdentityDbContext
    {
        public Form_AppContext(DbContextOptions<Form_AppContext> options) : base(options)
        {
        }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<TherapyModel> Therapies { get; set; }
    }
}
