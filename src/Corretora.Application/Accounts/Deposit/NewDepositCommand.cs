using Corretora.Application.Configuration;
using Corretora.Application.Sbp.Events;
using MediatR;

namespace Corretora.Application.Accounts.Deposit
{
    public class NewDepositCommand : IRequest<CommandResult>
    {
        public NewDepositCommand(TargetDto target, OriginDto origin, decimal amount)
        {
            Target = target;
            Origin = origin;
            Amount = amount;
        }

        public TargetDto Target { get; set; }
        public OriginDto Origin { get; set; }
        public decimal Amount { get; set; }
    }
}
