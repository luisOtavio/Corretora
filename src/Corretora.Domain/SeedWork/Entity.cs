using Corretora.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Corretora.Domain.SeedWork
{
    public abstract class Entity
    {
        Guid _Id;
        public virtual Guid Id
        {
            get { return _Id; }
            protected set { _Id = value; }
        }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }

        protected static void CheckRules(IEnumerable<IBusinessRule> rules)
        {
            foreach (var rule in rules)
            {
                CheckRule(rule);
            }
        }
    }
}
