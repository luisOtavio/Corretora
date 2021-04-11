using Corretora.Application.Accounts.Deposit;
using Corretora.Application.Sbp.Events;
using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.AggregatesModel.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Corretora.UnitTests.Application
{
    public class NewDepositCommandHandlerTests
    {
        private readonly Mock<IAccountRepository> _accountRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public NewDepositCommandHandlerTests()
        {
            _accountRepositoryMock = new Mock<IAccountRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task NewDepositCommandHandler_AccountNotFound_MustThrowException()
        {
            // Arrange
            _accountRepositoryMock
                .Setup(accountRepository => accountRepository.FindByNumberAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<Account>(null));

            var command = CreateFakeDepositCommand();

            var handler = new NewDepositCommandHandler(_accountRepositoryMock.Object, _userRepositoryMock.Object);

            var cltToken = new System.Threading.CancellationToken();

            // Act && Assert
            await Assert.ThrowsAsync<ApplicationException>(async () => await handler.Handle(command, cltToken));
        }

        [Fact]
        public async Task NewDepositCommandHandler_CpfNotEqual_MustThrowException()
        {
            // Arrange
            var accountFake = CreateFakeAccount();

            _accountRepositoryMock
                .Setup(accountRepository => accountRepository.FindByNumberAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(accountFake));

            var fakeUser = CreateFakeUser();

            _userRepositoryMock
                .Setup(userRepository => userRepository.FindAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(fakeUser));

            var command = CreateFakeDepositCommand(new Dictionary<string, object>{ ["cpf"] = "00000000000" });

            var handler = new NewDepositCommandHandler(_accountRepositoryMock.Object, _userRepositoryMock.Object);

            var cltToken = new System.Threading.CancellationToken();

            // Act && Assert
            await Assert.ThrowsAsync<ApplicationException>(async () => await handler.Handle(command, cltToken));
        }

        private Account CreateFakeAccount()
        {
            return new Account(number: AccountNumber.Create("1234"));
        }

        private User CreateFakeUser(string cpf = "012345678901")
        {
            return new User(name: "", cpf: Cpf.Create(cpf));
        }

        private NewDepositCommand CreateFakeDepositCommand(Dictionary<string, object> args = null)
        {
            return new NewDepositCommand(
                    target: new TargetDto
                    {
                        Account = args != null && args.ContainsKey("account") ? (string)args?["account"] : "1234",
                    },
                    origin: new OriginDto
                    {
                        Cpf = args != null && args.ContainsKey("cpf") ? (string)args?["cpf"] :  "012345678901",
                    },
                    amount: 0
                );
        }
    }
}
