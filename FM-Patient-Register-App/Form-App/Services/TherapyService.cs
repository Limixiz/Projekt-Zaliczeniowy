using Form_App.Context;
using Form_App.Models.DataBaseModel;
using Form_App.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_App.Services
{
    public class TherapyService : ITherapyService
    {
        private readonly Form_AppContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        async Task<int> ReturnUserID(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            return user.Id;
        }
        public TherapyService(Form_AppContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public int CountAllTherapies(int userId)
        {
            var numberOfTherapies = _context.Therapies.Where(x => x.ID == userId).Count();
            return numberOfTherapies;
        }

        public bool Create(Therapy therapy)
        {
            _context.Therapies.Add(therapy);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var therapy = _context.Therapies.SingleOrDefault(d => d.ID == id);
            if (therapy == null)
                return false;

            _context.Therapies.Remove(therapy);
            return _context.SaveChanges() > 0;
        }

        public Therapy Get(int id)
        {
            return _context.Therapies.SingleOrDefault(g => g.ID == id);
        }

        public IList<Therapy> GetAll()
        {
            return _context.Therapies.ToList();
        }


        public IList<Therapy> GetAllByLoggedUser(int id)
        {

            //var id = ReturnUserID(loggedUser);
           // int newID = await id;
            return _context.Therapies.Where(x => x.ApplicationUserID == id).ToList();
        }

        public int GetNumberOfUserTherapies(string userName)
        {
            return _context.Therapies.Where(x => x.Review == userName).Count();
        }

        public IList<Therapy> SearchAllBy(string SearchString)
        {
            var test = _context.Therapies.Where(r => r.Review.Contains(SearchString) || r.TherapyTecnics.Contains(SearchString)).ToList();
            return test;
        }

        public bool Update(Therapy therapy)
        {
            _context.Therapies.Update(therapy);
            return _context.SaveChanges() > 0;
        }
    }
}
