using BankingApplication.Model.Domain;
using System;

namespace BankingApplication.Model.Base
{
    public abstract class Account
    {
        public Account(Owner owner, string id, double balance)
        {
            this.Owner = owner ?? throw new Exception("Account must have an owner");
            this.Id = id;
            this.Balance = balance;
        }

        public string Id { get; private set; }

        public double Balance { get; private set; }

        public Owner Owner { get; private set; }

        public virtual void Deposit(double amount)
        {
            this.Balance += amount;
        }

        public virtual void Withdrawal(double amount)
        {
            if (amount > this.Balance)
            {
                throw new Exception("Not permissible to overdraft Account");
            }

            this.Balance -= amount;
        }

        public virtual void Transfer(Account toAccount, double amount)
        {
            this.Withdrawal(amount);
            toAccount.Deposit(amount);
        }
    }
}
