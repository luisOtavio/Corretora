using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Corretora.Infrastructure.Domain.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CorretoraDbContext _context;

        public AccountRepository(CorretoraDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Account> FindByNumberAsync(string number)
        {
            return await _context
              .Accounts
              .FirstOrDefaultAsync(account => account.Number.Value == number);
        }
    }
}
