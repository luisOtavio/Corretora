using Corretora.Domain.SeedWork;

namespace Corretora.Domain.AggregatesModel.Accounts.Rules
{
    public struct DepositAmountMustBeGreaterThanZeroRule : IBusinessRule
    {
        private readonly decimal _value;

        public string Message => "Deposit amount must be greater than zero";

        public DepositAmountMustBeGreaterThanZeroRule(decimal value)
        {
            _value = value;
        }

        public bool IsBroken()
        {
            return (_value <= 0);
        }
    }
}
