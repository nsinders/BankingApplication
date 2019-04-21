using BankingApplication.Model.Base;
using System;
using System.Collections.Generic;

namespace BankingApplication.Model.Domain
{
    public class Bank
    {
        public Bank(string id, string name, List<Account> accounts)
        {
            this.Id = id;
            this.Name = name;
            this.Accounts = accounts;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public List<Account> Accounts { get; private set; }
    }
}
