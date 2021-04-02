﻿using Corretora.Domain.AggregatesModel.Accounts.Rules;
using Corretora.Domain.SeedWork;
using System;

namespace Corretora.Domain.AggregatesModel.Accounts
{
    public class Account : Entity, IAggregateRoot
    {
        public AccountNumber Number { get; private set; }

        public decimal Balance { get; private set; }

        public Guid UserId { get; private set; }

        protected Account() { }

        private Account(AccountNumber number)
        {
            Number = number;
            Balance = 0;
        }

        public void Deposit(decimal value)
        {
            CheckRule(new DepositMustBeGreaterThanZeroRule());

            Balance += value;
        }

        public void Withdraw(decimal value)
        {
            CheckRule(new DepositMustBeGreaterThanZeroRule());

            Balance -= value;
        }       
    }
}