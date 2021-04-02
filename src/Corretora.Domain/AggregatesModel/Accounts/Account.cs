using Corretora.Domain.SeedWork;

namespace Corretora.Domain.AggregatesModel.Accounts
{
    public class Account : Entity, IAggregateRoot
    {
        public AccountNumber Number { get; private set; }

        public decimal Balance { get; private set; }
    }
}
