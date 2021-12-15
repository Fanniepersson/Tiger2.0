using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Tiger_2._0
{
    public class BankAccounts
    {

        public string AccountCurrency { get; set; }
        public string AccountName { get; set; }
        public decimal AccountBalance { get; set; }
        public BankAccounts(string accountName, decimal accountBalance, string currency)
        {
            this.AccountName = accountName;
            this.AccountBalance = accountBalance;
            this.AccountCurrency = currency;
        }
    }
}
