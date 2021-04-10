using Corretora.Domain.SeedWork;
using System.Threading.Tasks;

namespace Corretora.Domain.AggregatesModel.Accounts
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> FindByNumberAsync(string number);

        void Update(Account account);
    }
}
