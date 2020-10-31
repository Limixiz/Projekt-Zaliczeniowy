using Form_App.Context;
using Form_App.Models.DataBaseModel;
using Form_App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Form_App.Services
{
    public class PatientService : IPatientService
    {
        private readonly Form_AppContext _context;

        public PatientService(Form_AppContext context)
        {
            _context = context;
        }

        public bool CheckBeforeDelete(int id)
        {
            //var recipeCheck = _context.RecipePlans.Where(rp => rp.RecipeID == id).ToList();
            //if (recipeCheck.Count() == 0) return true;
            return true;
        }

        public int CountAllPatients(int userId)
        {
            var numberOfPatients = _context.Patients.Where(x => x.ID == userId).Count();
            return numberOfPatients;
        }

        public bool Create(Patient patient)
        {
            _context.Patients.Add(patient);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var patient = _context.Patients.SingleOrDefault(d => d.ID == id);
            if (patient == null)
                return false;

            _context.Patients.Remove(patient);
            return _context.SaveChanges() > 0;
        }

        public Patient Get(int id)
        {
            return _context.Patients.SingleOrDefault(g => g.ID == id);
        }

        public IList<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public IList<Patient> GetAllByLoggedUser(string loggedUser)
        {
            return _context.Patients.Where(x => x.ApplicationUser.UserName == loggedUser).ToList();
        }

        public int GetNumberOfUserPatients(string userName)
        {
            return _context.Patients.Where(x => x.Name == userName).Count();
        }

        public string GetPatientPersonalIdByPatientId(int patientId)
        {
            return _context.Patients.Where(p => p.ID == patientId).Select(s => s.PersonalId).FirstOrDefault();
        }
        public IList<Patient> SearchAllBy(string SearchString)
        {
            var test = _context.Patients.Where(r => r.Name.Contains(SearchString) || r.PersonalId.Contains(SearchString)).ToList();
            return test;
        }

        public bool Update(Patient patient)
        {
            _context.Patients.Update(patient);
            return _context.SaveChanges() > 0;
        }

        public bool IsTherapyInPatientDetails(int id)
        {
            var recipeCheck = _context.Therapies.Where(rp => rp.PatientID == id).ToList();
            if (recipeCheck.Count() == 0) return false;
            else return true;
        }
        public IList<Therapy> GetTherapiesforPatients(int id)
        {
            var patientTherapies  = _context.Therapies.Where(rp => rp.PatientID == id).Include(p => p.Patient).ToList();
            return patientTherapies;
        }
    }
}
