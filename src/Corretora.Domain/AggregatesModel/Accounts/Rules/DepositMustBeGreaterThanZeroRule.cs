using Corretora.Domain.SeedWork;

namespace Corretora.Domain.AggregatesModel.Accounts.Rules
{
    internal struct DepositMustBeGreaterThanZeroRule : IBusinessRule
    {
        private readonly decimal _value;

        public string Message => throw new System.NotImplementedException();

        public DepositMustBeGreaterThanZeroRule(decimal value)
        {
            _value = value;
        }

        public bool IsBroken()
        {
            return (_value <= 0);
        }
    }
}
