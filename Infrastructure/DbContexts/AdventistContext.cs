using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
    public class AdventistContext : DbContext
    {
        public AdventistContext(DbContextOptions<AdventistContext> options) : base(options) { }

        public DbSet<FeeNoRepo> FeeNos { get; set; }
        public DbSet<Vs_IdRepo> Vs_Ids { get; set; }
        public DbSet<HealthItemRepo> HealthItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<FeeNoRepo>().HasKey(f => f.Id);
            //modelBuilder.Entity<Vs_IdRepo>().HasKey(v => v.Id);
            //modelBuilder.Entity<HealthItemRepo>().HasKey(h => h.Id);
            
            //modelBuilder.Entity<HealthRepo>().HasIndex(f => f.DisplayKey).IsUnique();
        }
    }
}