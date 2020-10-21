using Microsoft.AspNetCore.Identity;

namespace Form_App.Models.DataBaseModel
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string roleName) : base(roleName)
        {

        }
    }
}
