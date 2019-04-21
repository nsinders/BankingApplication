using BankingApplication.Model;
using BankingApplication.Model.Base;
using BankingApplication.Model.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankingApplication.ModelTests
{
    [TestClass]
    public class CheckingAccountTests
    {
        private Account acct1;
        private Account acct2;
        private Owner owner;

        [TestInitialize]
        public void TestInitialize()
        {
            this.owner = new Owner("1", "Joe");
            this.acct1 = new CheckingAccount(owner, "1", 2000.76);
            this.acct2 = new IndividualInvestmentAccount(owner, "2", 500);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.owner = null;
            this.acct1 = null;
            this.acct2 = null;
        }

        [TestMethod]
        public void CheckingAccount_Constructor_Should_Fail_When_Creating_New_Account_Without_Owner()
        {
            Exception caughtException = null;

            try
            {
                Account badAcct = new CheckingAccount(null, "3", 2000.76);
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }

            Assert.IsNotNull(caughtException);
            Assert.AreEqual("Account must have an owner", caughtException.Message);
        }

        [TestMethod]
        public void CheckingAccount_Deposit_Should_Succeed()
        {
            double depositAmount = 100.00;
            double newAcct1Bal = this.acct1.Balance + depositAmount;

            this.acct1.Deposit(depositAmount);
            
            Assert.IsTrue(this.acct1 is CheckingAccount);
            Assert.AreEqual("1", this.acct1.Id);
            Assert.AreEqual(newAcct1Bal, this.acct1.Balance);
        }

        [TestMethod]
        public void CheckingAccount_Withdrawal_Should_Succeed()
        {
            double withdrawalAmount = 1500.00;
            double newAcct1Bal = this.acct1.Balance - withdrawalAmount;

            this.acct1.Withdrawal(withdrawalAmount);

            Assert.IsTrue(this.acct1 is CheckingAccount);
            Assert.AreEqual("1", this.acct1.Id);
            Assert.AreEqual(newAcct1Bal, this.acct1.Balance);
        }

        [TestMethod]
        public void CheckingAccount_Withdrawal_Should_Fail_When_Trying_To_Overdraft_Account()
        {
            Exception caughtException = null;
            double withdrawalAmount = 500000.00;

            try
            {
                this.acct1.Withdrawal(withdrawalAmount);
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }

            Assert.IsNotNull(caughtException);
            Assert.AreEqual("Not permissible to overdraft Account", caughtException.Message);
        }

        [TestMethod]
        public void CheckingAccount_Transfer_Should_Succeed()
        {
            double transferAmount = 100.00;
            double newAcct1Bal = this.acct1.Balance - transferAmount;
            double newAcct2Bal = this.acct2.Balance + transferAmount;

            this.acct1.Transfer(this.acct2, 100.00);

            Assert.IsTrue(this.acct1 is CheckingAccount);
            Assert.AreEqual("1", this.acct1.Id);
            Assert.AreEqual(newAcct1Bal, this.acct1.Balance);

            Assert.IsTrue(this.acct2 is IndividualInvestmentAccount);
            Assert.AreEqual("2", this.acct2.Id);
            Assert.AreEqual(newAcct2Bal, this.acct2.Balance);
        }

        [TestMethod]
        public void CheckingAccount_Transfer_Should_Fail_When_Trying_To_Overdraft_Account()
        {
            Exception caughtException = null;
            double transferAmount = 5000.00;

            try
            {
                this.acct1.Transfer(this.acct2, transferAmount);
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }

            Assert.IsNotNull(caughtException);
            Assert.AreEqual("Not permissible to overdraft Account", caughtException.Message);
        }
    }
}
