using BankingApplication.Model.Base;
using BankingApplication.Model.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BankingApplication.ModelTests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void Bank_Constructor_Should_Succeed_When_Creating_New_Bank_With_Multiple_Accounts()
        {
            Owner owner1 = new Owner("1", "Joe");
            Owner owner2 = new Owner("2", "Walmart");

            Account acct1 = new CheckingAccount(owner1, "1", 2000.76);
            Account acct2 = new IndividualInvestmentAccount(owner1, "2", 500.00);
            Account acct3 = new CorporateInvestmentAccount(owner2, "3", 7000000.00);

            List<Account> chaseAccounts = new List<Account>
            {
                acct1,
                acct2,
                acct3
            };

            Bank chaseBank = new Bank("1", "Chase", chaseAccounts);

            Assert.AreEqual("1", chaseBank.Id);
            Assert.AreEqual("Chase", chaseBank.Name);
            Assert.AreEqual(chaseAccounts.Count, chaseBank.Accounts.Count);
            Assert.IsTrue(chaseBank.Accounts[0] is CheckingAccount);
            Assert.AreEqual(owner1.Id, chaseBank.Accounts[0].Owner.Id);
            Assert.AreEqual(owner1.Name, chaseBank.Accounts[0].Owner.Name);
            Assert.IsTrue(chaseBank.Accounts[1] is IndividualInvestmentAccount);
            Assert.AreEqual(owner1.Id, chaseBank.Accounts[0].Owner.Id);
            Assert.AreEqual(owner1.Name, chaseBank.Accounts[1].Owner.Name);
            Assert.IsTrue(chaseBank.Accounts[2] is CorporateInvestmentAccount);
            Assert.AreEqual(owner1.Id, chaseBank.Accounts[0].Owner.Id);
            Assert.AreEqual(owner2.Name, chaseBank.Accounts[2].Owner.Name);
        }
    }
}
