using System;
namespace Project_Tiger_2._0
{
    public class Transaction
    {
        public decimal AmountTransaction { get; set; }
        public DateTime Date { get; set; }
        public string AccountName { get; set; }
        public string AccountName2 { get; set; }

        public Transaction(decimal amountTransaction, DateTime date, string accountName, string accountName2)
        {
            this.AmountTransaction = amountTransaction;
            this.Date = date;
            this.AccountName = accountName;
            this.AccountName2 = accountName2;
        }
    }
}
