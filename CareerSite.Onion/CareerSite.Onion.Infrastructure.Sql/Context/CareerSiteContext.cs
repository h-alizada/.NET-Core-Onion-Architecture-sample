using CareerSite.Onion.Infrastructure.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerSite.Onion.Infrastructure.Sql.Context
{
	public class CareerSiteContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Test;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<JobApplicationEntity> JobApplications { get; set; }
	}
}
