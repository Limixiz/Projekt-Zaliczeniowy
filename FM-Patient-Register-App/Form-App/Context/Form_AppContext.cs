using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Form_App.Context
{
    public class Form_AppContext : IdentityDbContext
    {
        public Form_AppContext(DbContextOptions<Form_AppContext> options) : base(options)
        {

        }
    }
}
