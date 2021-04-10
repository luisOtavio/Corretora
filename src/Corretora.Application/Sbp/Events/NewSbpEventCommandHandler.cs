using Corretora.Application.Accounts.Deposit;
using Corretora.Application.Configuration;
using Corretora.Application.Configuration.Mediator;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Corretora.Application.Sbp.Events
{
    public class NewSbpEventCommandHandler : IRequestHandler<NewSbpEventCommand, CommandResult>
    {
        private readonly IMediatorHandler _mediator;

        public NewSbpEventCommandHandler(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public async Task<CommandResult> Handle(NewSbpEventCommand request, CancellationToken cancellationToken)
        {
            IRequest<CommandResult> command = null;

            switch (request.Event)
            {
                case "TRANSFER":
                    command = new NewDepositCommand(request.Target, request.Origin, request.Amount);
                    break;
                default:
                    break;
            }

            return await _mediator.SendCommand(command);
        }
    }
}
