using BestPlanFood.Models.Db;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BestPlanFood.Context
{
    public class PlanFoodContext : IdentityDbContext
	{
		public PlanFoodContext(DbContextOptions<PlanFoodContext> options) : base(options)
		{
		}
		public DbSet<PlanModel> Plans { get; set; }
		public DbSet<DayNamesModel> DayNames { get; set; }
		public DbSet<RecipeModel> Recipes { get; set; }
		public DbSet<RecipePlansModel> RecipePlans { get; set; }
	}
}
