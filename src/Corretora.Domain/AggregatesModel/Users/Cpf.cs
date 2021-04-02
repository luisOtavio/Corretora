using Corretora.Domain.SeedWork;
using System.Collections.Generic;

namespace Corretora.Domain.AggregatesModel.Users
{
    public class Cpf : ValueObject
    {

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }
    }
}