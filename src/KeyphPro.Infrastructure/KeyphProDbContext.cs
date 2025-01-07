using Microsoft.EntityFrameworkCore;
using KeyphPro.Domain.Entities.Database;

namespace KeyphPro.Infrastructure.Data
{
    public class KeyphProDbContext : DbContext
    {
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<Audit> Audits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=KeyphPro.db");
        }
    }
}