using Corretora.Application.Configuration;
using Corretora.Domain.AggregatesModel.Accounts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Corretora.Application.Accounts.Deposit
{
    public class NewDepositCommandHandler : IRequestHandler<NewDepositCommand, CommandResult>
    {
        private readonly IAccountRepository _accountRepository;

        public NewDepositCommandHandler(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public Task<CommandResult> Handle(NewDepositCommand request, CancellationToken cancellationToken)
        {


            return null;
        }
    }
}
