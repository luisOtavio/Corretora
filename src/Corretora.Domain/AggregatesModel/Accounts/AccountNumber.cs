using Corretora.Domain.SeedWork;
using System.Collections.Generic;

namespace Corretora.Domain.AggregatesModel.Accounts
{
    public class AccountNumber : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }
    }
}