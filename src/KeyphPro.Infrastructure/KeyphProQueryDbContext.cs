using Microsoft.EntityFrameworkCore;
using KeyphPro.Domain.Entities.Database;

namespace KeyphPro.Infrastructure.Data
{
    public class KeyphProQueryDbContext : DbContext
    {
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<StoredScript> StoredScripts { get; set; }
        public KeyphProQueryDbContext(DbContextOptions<KeyphProQueryDbContext> options)
       : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=KeyphPro.db");
        }
    }
}