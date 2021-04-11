using Corretora.Application.Configuration.Exceptions;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Corretora.Application.Configuration.Behaviors
{
    public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, CommandResult>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<CommandResult> Handle(
            TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<CommandResult> next)
        {
            var errors = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .Select(error => error.ErrorMessage)
                .ToList();

            if (errors.Any())
            {
                throw new InvalidCommandException(errors);
            }

            return next();
        }
    }
}
