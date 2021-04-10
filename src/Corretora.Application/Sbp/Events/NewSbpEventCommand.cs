using Corretora.Application.Configuration;
using MediatR;

namespace Corretora.Application.Sbp.Events
{
    public class NewSbpEventCommand : IRequest<CommandResult>
    {
        public string Event { get; set; }
        public TargetDto Target { get; set; }
        public OriginDto Origin { get; set; }
        public decimal Amount { get; set; }
    }

    public class TargetDto
    {
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string Account { get; set; }
    }

    public class OriginDto
    {
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string Cpf { get; set; }
    }
}
