using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Infrastructure.Domain.Accounts;
using Microsoft.Extensions.DependencyInjection;

namespace Corretora.Infrastructure.Bootstrap
{
    public static class Bootstrap
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
