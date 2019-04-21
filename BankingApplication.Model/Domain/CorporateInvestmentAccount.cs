using BankingApplication.Model.Base;

namespace BankingApplication.Model.Domain
{
    public class CorporateInvestmentAccount : Account
    {
        public CorporateInvestmentAccount(Owner owner, string id, double balance) : base(owner, id, balance)
        {
        }
    }
}
