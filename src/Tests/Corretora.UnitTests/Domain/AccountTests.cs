using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.AggregatesModel.Accounts.Rules;
using Corretora.Domain.Exceptions;
using Xunit;

namespace Corretora.UnitTests.Domain
{
    public class AccountTests
    {
        [Fact]
        public void Account_Deposit_MustIncreaseAccountBalance()
        {
            // Arrange
            var account = new Account(AccountNumber.Create(""));

            var amount1 = 5500.34M;
            var amount2 = 200.27M;
            var expectedBalance = (amount1 + amount2);

            // Act
            account.Deposit(amount1);
            account.Deposit(amount2);

            // Assert
            Assert.Equal(expectedBalance, account.Balance);
        }


        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        public void Account_DepositAmountLessOrEqualToZero_MustThrowBusinessException(decimal amount)
        {
            // Arrange
            var account = new Account(AccountNumber.Create(""));

            // Act & Assert
           var exception = Assert.Throws<BusinessRuleValidationException>(() => account.Deposit(amount));
           Assert.IsType<DepositAmountMustBeGreaterThanZeroRule>(exception.BrokenRule);
        }
    }
}