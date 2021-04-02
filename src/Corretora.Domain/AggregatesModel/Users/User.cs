﻿using Corretora.Domain.SeedWork;

namespace Corretora.Domain.AggregatesModel.Users
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public Cpf Cpf { get; private set; }
    }
}
