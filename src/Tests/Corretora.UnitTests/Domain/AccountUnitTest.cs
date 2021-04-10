using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.AggregatesModel.Accounts.Rules;
using System;
using Xunit;

namespace Corretora.UnitTests.Domain
{
    public class AccountUnitTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var account = new Account(AccountNumber.Create(""));

            var deposit1 = 5500.34M;
            var deposit2 = 200.27M;
            var expectedBalance = (deposit1 + deposit2);

            // Act
            account.Deposit(deposit1);
            account.Deposit(deposit2);

            // Assert
            Assert.Equal(expectedBalance, account.Balance);
        }


        //[Fact]
        //public void Test2()
        //{
        //    // Arrange
        //    var account = new Account(AccountNumber.Create(""));

        //    // Act & Assert
        //    Assert.Throws<DepositMustBeGreaterThanZeroRule>(() => account.Deposit(0) );
        //}
    }
}


