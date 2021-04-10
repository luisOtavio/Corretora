namespace Corretora.Domain.SeedWork
{
    // TODO veridicar se é necessário implementar o IDisposable
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
