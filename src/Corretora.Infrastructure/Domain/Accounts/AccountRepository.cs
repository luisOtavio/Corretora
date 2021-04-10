using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.SeedWork;
using Corretora.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Corretora.Infrastructure.Domain.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CorretoraContext _context;

        public AccountRepository(CorretoraContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Account> FindByNumberAsync(string number)
        {
            return await _context
              .Accounts
              .FirstOrDefaultAsync(account => account.Number.Value == number);
        }

        public void Update(Account account)
        {
             _context.Accounts.Update(account);
        }
    }
}
