using KeyphPro.Domain.Entities.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KeyphPro.Infrastructure.Data
{
    public class KeyphProQueryDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public KeyphProQueryDbContext(DbContextOptions<KeyphProQueryDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string strConnection = _configuration.GetConnectionString("QueryConnection")
             ?? throw new InvalidOperationException("Connection string 'QueryConnection' not found.");

            optionsBuilder.UseSqlite(strConnection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<StoredScript> StoredScripts { get; set; }
        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}