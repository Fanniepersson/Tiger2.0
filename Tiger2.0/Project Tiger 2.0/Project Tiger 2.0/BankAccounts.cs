using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Tiger_2._0
{
    public class BankAccounts
    {

        public decimal Amount { get; }
        public string AccountName { get; set; }
        public decimal AccountBalance { get; set; }
        public BankAccounts(string accountName, decimal accountBalance)
        {
            this.AccountName = accountName;
            this.AccountBalance = accountBalance;
        }

        //public Transaction (decimal amount) //Nytt
        //{
        //    this.Amount = amount;
        //}
    }
}
