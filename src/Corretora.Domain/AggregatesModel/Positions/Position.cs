using Corretora.Domain.SeedWork;
using System;

namespace Corretora.Domain.AggregatesModel.Positions
{
    public class Position : Entity, IAggregateRoot
    {
        public string Symbol { get; private set; }

        public int Amount { get; private set; }

        public decimal CurrentPrice { get; private set; }

        public Guid UserId { get; private set; }
    }
}
