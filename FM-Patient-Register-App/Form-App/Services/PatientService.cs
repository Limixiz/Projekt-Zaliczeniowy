using Form_App.Context;
using Form_App.Models.DataBaseModel;
using Form_App.Services.Interfaces;
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

        public bool Create(PatientModel patient)
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

        public PatientModel Get(int id)
        {
            return _context.Patients.SingleOrDefault(g => g.ID == id);
        }

        public IList<PatientModel> GetAll()
        {
            return _context.Patients.ToList();
        }

        public IList<PatientModel> GetAllByLoggedUser(string loggedUser)
        {
            return _context.Patients.Where(x => x.Name == loggedUser).ToList();
        }

        public int GetNumberOfUserPatients(string userName)
        {
            return _context.Patients.Where(x => x.Name == userName).Count();
        }

        public IList<PatientModel> SearchAllBy(string SearchString)
        {
            var test = _context.Patients.Where(r => r.Name.Contains(SearchString) || r.PersonalId.Contains(SearchString)).ToList();
            return test;
        }

        public bool Update(PatientModel patient)
        {
            _context.Patients.Update(patient);
            return _context.SaveChanges() > 0;
        }
    }
}
