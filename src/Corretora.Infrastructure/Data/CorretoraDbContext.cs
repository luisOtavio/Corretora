using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.AggregatesModel.Users;
using Microsoft.EntityFrameworkCore;

namespace Corretora.Infrastructure.Data
{
    public class CorretoraDbContext : DbContext
    {

        public DbSet<Account> Accounts { get; set; }

        public DbSet<User> Users { get; set; }

        public CorretoraDbContext(DbContextOptions<CorretoraDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
           => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
