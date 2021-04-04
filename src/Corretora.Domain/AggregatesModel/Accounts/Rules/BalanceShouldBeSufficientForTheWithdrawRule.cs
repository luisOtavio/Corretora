using Corretora.Domain.SeedWork;

namespace Corretora.Domain.AggregatesModel.Accounts.Rules
{
    internal struct BalanceShouldBeSufficientForTheWithdrawRule : IBusinessRule
    {
        private readonly decimal _balance;

        public string Message => throw new System.NotImplementedException();

        public BalanceShouldBeSufficientForTheWithdrawRule(decimal balance)
        {
            _balance = balance;
        }

        public bool IsBroken()
        {
            throw new System.NotImplementedException();
        }
    }
}
