using Form_App.Models.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_App.Services.Interfaces
{
    interface IPatientService
    {
        bool Create(PatientModel patient);
        PatientModel Get(int id);
        IList<PatientModel> GetAll();
        public int GetNumberOfUserPatients(string userName);
        bool Update(PatientModel patient);
        public bool CheckBeforeDelete(int id);
        bool Delete(int id);
        public int CountAllPatients(string loggedUser);

        public IList<PatientModel> GetAllByLoggedUser(string loggedUser);
        public IList<PatientModel> SearchAllBy(string SearchString);
    }
}
