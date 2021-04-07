using Corretora.Domain.SeedWork;
using System.Collections.Generic;

namespace Corretora.Domain.AggregatesModel.Accounts
{
    public class AccountNumber : ValueObject
    {
        public string Value { get; }

        private AccountNumber(string value)
        {
            Value = value;
        }

        public static AccountNumber Create(string number)
        {
            return new AccountNumber(number);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}