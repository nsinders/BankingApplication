using BankingApplication.Model.Base;

namespace BankingApplication.Model.Domain
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(Owner owner, string id, double balance) : base(owner, id, balance)
        {
        }
    }
}
