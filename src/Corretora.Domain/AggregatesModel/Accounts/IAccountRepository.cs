using System.Threading.Tasks;

namespace Corretora.Domain.AggregatesModel.Accounts
{
    public interface IAccountRepository
    {
        Task<Account> FindByNumberAsync(string number);
    }
}
