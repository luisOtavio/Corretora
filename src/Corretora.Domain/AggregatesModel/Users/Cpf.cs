using Corretora.Domain.SeedWork;
using System.Collections.Generic;

namespace Corretora.Domain.AggregatesModel.Users
{
    public class Cpf : ValueObject
    {
        public string Value { get; }

        protected Cpf() { }

        private Cpf(string value)
        {
            Value = value;
        }

        public static Cpf Create(string number)
        {
            return new Cpf(number);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}