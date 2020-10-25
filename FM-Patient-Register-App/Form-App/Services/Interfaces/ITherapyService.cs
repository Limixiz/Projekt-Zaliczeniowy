using Form_App.Models.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_App.Services.Interfaces
{
    public interface ITherapyService
    {
        bool Create(Therapy therapy);
        Therapy Get(int id);
        IList<Therapy> GetAll();
        public int GetNumberOfUserTherapies(string userName);
        bool Update(Therapy therapy);
        public int CountAllTherapies(int userId);

        public IList<Therapy> GetAllByLoggedUser(int id);

        public IList<Therapy> SearchAllBy(string SearchString);
    }
}
