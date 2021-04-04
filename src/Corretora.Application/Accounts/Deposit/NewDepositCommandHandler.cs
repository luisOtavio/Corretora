using Corretora.Application.Configuration;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Corretora.Application.Accounts.Deposit
{
    public class NewDepositCommandHandler : IRequestHandler<NewDepositCommand, CommandResult>
    {
        public Task<CommandResult> Handle(NewDepositCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
