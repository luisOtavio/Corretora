using Corretora.Application.Configuration.Mediator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Corretora.Api.Configuration.Extensions
{
    internal static class DependencyInjectionMediatR
    {
        internal static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));

            services
                .AddMediatR(Application.Assemblies.Value)
                .AddScoped<IMediatorHandler, MediatorHandler>();
                //.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                //.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>))
                //.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionCommandBehavior<,>));

            return services;
        }
    }
}
