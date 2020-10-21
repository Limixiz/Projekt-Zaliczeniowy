using Microsoft.AspNetCore.Identity;

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
    }
}
