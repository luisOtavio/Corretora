using Corretora.Application.Accounts.Deposit;
using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.AggregatesModel.Users;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Corretora.UnitTests.Application
{
    public class NewDepositCommandHandlerTest
    {
        private readonly Mock<IAccountRepository> _accountRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public NewDepositCommandHandlerTest()
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

            var command = new NewDepositCommand
            {
                Target = new TargetDto
                {
                    Account = ""
                }
            };

            var handler = new NewDepositCommandHandler(_accountRepositoryMock.Object, _userRepositoryMock.Object);

            var cltToken = new System.Threading.CancellationToken();

            // Act && Assert
            await Assert.ThrowsAsync<ApplicationException>(async () => await handler.Handle(command, cltToken));
        }
    }
}
