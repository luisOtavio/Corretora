using Corretora.Application.Configuration.Exceptions;
using Corretora.Domain.Exceptions;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Corretora.Api.Infrastructure.DependencyInjection
{
    internal static class DependencyInjectionProblemDetails
    {
        internal static IServiceCollection RegisterProblemDetails(this IServiceCollection services)
        {
            services.AddProblemDetails(ex =>
            {
                ex.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                ex.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
            });

            return services;
        }
    }

    internal class BusinessRuleValidationExceptionProblemDetails : ProblemDetails
    {
        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
        {
            Title = "Business rule broken";
            Status = StatusCodes.Status409Conflict;
            Detail = exception.Message;
            Type = "https://somedomain/business-rule-validation-error";
        }
    }

    internal class InvalidCommandProblemDetails : ProblemDetails
    {
        public IList<string> Messages { get; }

        public InvalidCommandProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
            Title = "Invalid command";
            Status = StatusCodes.Status409Conflict;
            Detail = "Check the messages for more details";
        }

        public InvalidCommandProblemDetails(InvalidCommandException exception) : this()
        {
            Messages = exception.Errors;
        }

        public InvalidCommandProblemDetails(IList<string> messages) : this()
        {
            Messages = messages;
        }
    }
}
