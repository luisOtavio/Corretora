using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Corretora.Application.Configuration.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                _logger.LogInformation("1 -- Handling command {RequestName} ({@Request})", typeof(TRequest).Name, request);
                var response = await next();
                _logger.LogInformation("2 -- Command {RequestName} handled - response: {@Response}", typeof(TRequest).Name, response);

                return response;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Command processing failed");
                throw;
            }
        }
    }
}
