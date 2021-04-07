using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.AggregatesModel.Users;
using Corretora.Infrastructure.Domain.Accounts;
using Corretora.Infrastructure.Domain.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Corretora.Infrastructure.Bootstrap
{
    public static class Bootstrap
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
        {
            services
                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
