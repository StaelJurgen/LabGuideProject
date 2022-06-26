using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Infrastructure.Data.Seeding;

namespace PRI.Project.Labogids.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<ReferenceValue> ReferenceValues { get; set; }
        public DbSet<RequestDefinition> RequestDefinitions { get; set; }
        public DbSet<Specimen> Specimens { get; set; }
        public DbSet<StorageCondition> StorageConditions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
