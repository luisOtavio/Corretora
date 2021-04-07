﻿using Corretora.Application.Configuration;
using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.AggregatesModel.Users;
using MediatR;
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

        public  async Task<CommandResult> Handle(NewDepositCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.FindByNumberAsync(request.Target.Account);

            if (account == null)
            {

            }

            var user = await _userRepository.FindAsync(account.UserId);

            if (request.Origin.Cpf != user.Cpf.Value)
            {

            }

            return null;
        }
    }
}
