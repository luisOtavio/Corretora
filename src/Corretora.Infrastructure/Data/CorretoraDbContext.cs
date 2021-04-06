using Microsoft.EntityFrameworkCore;

namespace Corretora.Infrastructure.Data
{
    public class CorretoraDbContext : DbContext
    {
        public CorretoraDbContext(DbContextOptions<CorretoraDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
           => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
