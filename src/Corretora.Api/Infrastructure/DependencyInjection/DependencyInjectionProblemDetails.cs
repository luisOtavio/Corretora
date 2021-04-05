using Hellang.Middleware.ProblemDetails;
using Microsoft.Extensions.DependencyInjection;

namespace Corretora.Api.Infrastructure.DependencyInjection
{
    internal static class DependencyInjectionProblemDetails
    {
        internal static IServiceCollection RegisterProblemDetails(this IServiceCollection services)
        {
            services.AddProblemDetails(ex =>
            {
                //ex.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                //ex.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
            });

            return services;
        }
    }
}
