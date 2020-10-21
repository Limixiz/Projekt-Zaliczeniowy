using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Form_App.Models.DataBaseModel
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }

        public List<Patient> Patients { get; set; }
    }
}
