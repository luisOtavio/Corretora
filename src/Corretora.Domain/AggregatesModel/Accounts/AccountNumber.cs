using Corretora.Domain.SeedWork;
using System.Collections.Generic;

namespace Corretora.Domain.AggregatesModel.Accounts
{
    public class AccountNumber : ValueObject
    {
        readonly string _value;

        private AccountNumber(string value)
        {
            _value = value;
        }

        public static AccountNumber Create(string number)
        {
            return new AccountNumber(number);
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }
    }
}