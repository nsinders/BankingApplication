using BankingApplication.Model.Base;
using System;

namespace BankingApplication.Model.Domain
{
    public class IndividualInvestmentAccount : Account
    {
        public IndividualInvestmentAccount(Owner owner, string id, double balance) : base(owner, id, balance)
        {
        }

        public override void Withdrawal(double amount)
        {
            if (amount > 1000.00)
            {
                throw new Exception("Individual Investment Accounts can only withdraw up to $1,000 at a time");
            }

            base.Withdrawal(amount);
        }

        public override void Transfer(Account toAccount, double amount)
        {
            base.Withdrawal(amount);
            toAccount.Deposit(amount);
        }
    }
}
