using Corretora.Domain.AggregatesModel.Users;
using Corretora.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Corretora.Infrastructure.Domain.Users
{
    internal class UserRepository : IUserRepository
    {
        private readonly CorretoraContext _context;

        public UserRepository(CorretoraContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<User> FindAsync(Guid userId)
        {
            return _context
                .Users
                .FirstOrDefaultAsync(user => user.Id == userId);
        }
    }
}
