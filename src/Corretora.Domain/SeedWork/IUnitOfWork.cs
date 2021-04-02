using System;
using System.Threading;
using System.Threading.Tasks;

namespace Corretora.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
