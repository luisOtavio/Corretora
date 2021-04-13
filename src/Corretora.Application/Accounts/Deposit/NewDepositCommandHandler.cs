using Corretora.Application.Configuration;
using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.AggregatesModel.Users;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Corretora.Application.Accounts.Deposit
{
    public class NewDepositCommandHandler : IRequestHandler<NewDepositCommand, CommandResult>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public NewDepositCommandHandler(
            IAccountRepository accountRepository,
            IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public  async Task<CommandResult> Handle(NewDepositCommand command, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.FindByNumberAsync(command.Target.Account);

            if (account == null)
            {
                throw new ApplicationException("Account not found");
            }

            var user = await _userRepository.FindAsync(account.UserId);

            if (command.Origin.Cpf != user.Cpf.Value)
            {
                throw new ApplicationException("CPF not found");
            }

            account.Deposit(command.Amount);

            _accountRepository.Update(account);
            await _accountRepository.UnitOfWork.CommitAsync();
             
            return CommandResult.Ok(new { account.Balance });
        }


    }
}
