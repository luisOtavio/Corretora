using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.AggregatesModel.Users;
using MediatR;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Corretora.UnitTests.Application
{
    public class NewDepositCommandHandlerTest
    {
        private readonly Mock<IAccountRepository> _orderRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IMediator> _mediator;

        public NewDepositCommandHandlerTest()
        {

            _orderRepositoryMock = new Mock<IAccountRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task NewDepositCommandHandler_AccountNotFound_MustThrowException()
        {
            
        }
    }
}
