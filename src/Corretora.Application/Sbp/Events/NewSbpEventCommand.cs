using Corretora.Application.Configuration;
using MediatR;

namespace Corretora.Application.Sbp.Events
{
    public class NewSbpEventCommand : IRequest<CommandResult>
    {
    }
}
