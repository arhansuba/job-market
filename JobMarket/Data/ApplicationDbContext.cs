using JobMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace JobMarket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<JobCategory> JobCategories { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<JobOffer> JobOffers { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
