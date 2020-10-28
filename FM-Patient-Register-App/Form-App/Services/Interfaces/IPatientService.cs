using Form_App.Models.DataBaseModel;
using System.Collections.Generic;

namespace Form_App.Services.Interfaces
{
    public interface IPatientService
    {
        bool Create(Patient patient);
        Patient Get(int id);
        IList<Patient> GetAll();
        public int GetNumberOfUserPatients(string userName);
        bool Update(Patient patient);
        public bool CheckBeforeDelete(int id);
        bool Delete(int id);
        public int CountAllPatients(int userId);
        public string GetPatientPersonalIdByPatientId(int patientId);
        public IList<Patient> GetAllByLoggedUser(string loggedUser);
        public IList<Patient> SearchAllBy(string SearchString);
    }
}
