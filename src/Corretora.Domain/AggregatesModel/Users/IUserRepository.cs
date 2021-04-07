using System;
using System.Threading.Tasks;

namespace Corretora.Domain.AggregatesModel.Users
{
    public interface IUserRepository
    {
        Task<User> FindAsync(Guid userId);
    }
}
