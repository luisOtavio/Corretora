using Corretora.Domain.Exceptions;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
}
