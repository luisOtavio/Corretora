using Corretora.Domain.SeedWork;

namespace Corretora.Domain.AggregatesModel.Accounts.Rules
{
    public class DepositMustBeGreaterThanZeroRule : IBusinessRule
    {
        public string Message => throw new System.NotImplementedException();

        public bool IsBroken()
        {
            throw new System.NotImplementedException();
        }
    }
}
