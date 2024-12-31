using Assesment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<task> Tasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(t => t.Tasks)
               .WithOne(t => t.Project)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TeamMember>()
                .HasMany(t=>t.tasks)
                .WithOne(t=>t.TeamMember)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
