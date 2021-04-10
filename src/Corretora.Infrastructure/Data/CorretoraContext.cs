using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.AggregatesModel.Users;
using Corretora.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Corretora.Infrastructure.Data
{
    public class CorretoraContext : DbContext, IUnitOfWork
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<User> Users { get; set; }

        public CorretoraContext(DbContextOptions<CorretoraContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
           => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
           return await base.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
