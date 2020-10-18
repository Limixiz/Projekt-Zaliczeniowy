using Form_App.Models.DataBaseModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Form_App.ViewModels.PatientsInformationModels;

namespace Form_App.Context
{
    public class Form_AppContext : IdentityDbContext
    {
        public Form_AppContext(DbContextOptions<Form_AppContext> options) : base(options)
        {
        }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<TherapyModel> Therapies { get; set; }
        public DbSet<Form_App.ViewModels.PatientsInformationModels.DetailsPatienInfoViewModel> DetailsPatienInfoViewModel { get; set; }
        public DbSet<Form_App.ViewModels.PatientsInformationModels.PatientInfo> PatientInfo { get; set; }
        public DbSet<Form_App.ViewModels.PatientsInformationModels.EditPatientInfo> EditPatientInfo { get; set; }
        public DbSet<Form_App.ViewModels.PatientsInformationModels.DeletePatientInfoViewModel> DeletePatientInfoViewModel { get; set; }
    }
}
