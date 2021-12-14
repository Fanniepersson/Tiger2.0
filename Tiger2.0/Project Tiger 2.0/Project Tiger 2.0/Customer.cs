using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Tiger_2._0
{
    public class Customer : Users
    {
        public List<Transaction> listOfYourAccountTransactions = new List<Transaction>();
        public List<Transaction> listOfTransactionsToOtherCustomers = new List<Transaction>();
        public List<Transaction> listOfRemovedAccounts = new List<Transaction>();
        public List<Transaction> listOfAddedAccounts = new List<Transaction>();
        public List<BankAccounts> listOfBankAccounts = new List<BankAccounts>();
        public void MainMenuC(List<Customer> listOfCustomers, int loggedInUserIndex)
        {
            bool logOut = false;
            while (logOut == false)
            {
                Console.Clear();
                Console.WriteLine("Välj ett av valen nedan i menyn:");
                Console.WriteLine("1 --- Se dina konton & saldo.");
                Console.WriteLine("2 --- Överföring av pengar mellan dina konton.");
                Console.WriteLine("3 --- Överför dina pengar till en annan användare.");
                Console.WriteLine("4 --- Öppna upp ett nytt konto.");
                Console.WriteLine("5 --- Avsluta ett existerande konto.");
                Console.WriteLine("6 --- Se din konto historik.");
                Console.WriteLine("7 --- Logga ut.");

                string choice = Console.ReadLine();
                switch (choice)
                {

                    case "1":
                        listOfCustomers[loggedInUserIndex].PrintBankAccounts();
                        break;


                    case "2":
                        listOfCustomers[loggedInUserIndex].TransferMoneyToAnotherAccount();
                        break;

                    case "3":
                        listOfCustomers[loggedInUserIndex].TransferMoneyToAnotherCustomer(listOfCustomers, loggedInUserIndex);
                        break;

                    case "4":
                        listOfCustomers[loggedInUserIndex].CreateNewAccount();
                        break;

                    case "5":
                        listOfCustomers[loggedInUserIndex].RemoveExistingAccount();
                        break;

                    case "6":
                        listOfCustomers[loggedInUserIndex].PrintTransactionHistory();
                        break;

                    case "7":
                        logOut = true;
                        break;

                    default:
                        Console.WriteLine("Felaktig inmatning. Tryck på enter för att återgå till menyn.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void PrintBankAccounts() // Denna metoden rör vanliga kunder.
        {
            Console.Clear();
            Console.WriteLine("Dina konton och saldo");
            Console.WriteLine();
            for (int i = 0; i < listOfBankAccounts.Count; i++)
            {
                Console.Write(listOfBankAccounts[i].AccountName);
                Console.Write(" --- ");
                Console.Write(listOfBankAccounts[i].AccountBalance);
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Tryck på enter för att återgå till menyn.");
            Console.ReadKey();
        }

        public void TransferMoneyToAnotherAccount()
        {
            Console.Clear();
            bool loop = true;
            int accountChoice = 0;
            while (loop)
            {
                for (int i = 0; i < listOfBankAccounts.Count; i++)
                {
                    Console.Write(i + " --- ");
                    Console.Write(listOfBankAccounts[i].AccountName);
                    Console.Write(" --- ");
                    Console.Write(listOfBankAccounts[i].AccountBalance);
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.WriteLine("Välj vilket konto du vill föra över pengar ifrån:");
                try
                {
                    accountChoice = Convert.ToInt32(Console.ReadLine());
                }

                catch
                {
                    Console.WriteLine("Ogiltligt val");
                }

                if (accountChoice < listOfBankAccounts.Count)
                {
                    loop = false;
                }
                else if (accountChoice >= listOfBankAccounts.Count)
                {
                    Console.WriteLine("Kontot finns inte i systemet");
                }

            }

            bool loop2 = true;
            int transferToAcount = 0;
            while (loop2)
            {
                for (int i = 0; i < listOfBankAccounts.Count; i++)
                {
                    Console.Write(i + " --- ");
                    Console.Write(listOfBankAccounts[i].AccountName);
                    Console.Write(" --- ");
                    Console.Write(listOfBankAccounts[i].AccountBalance);
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.WriteLine("Välj vilket konto du vill föra över pengar till:");
                try
                {
                    transferToAcount = Convert.ToInt32(Console.ReadLine());
                }

                catch
                {
                    Console.WriteLine("Ogiltligt val");
                }
                if (transferToAcount == accountChoice)
                {
                    Console.WriteLine("Du kan inte föra över pengar till samma konto");
                }

                else if (transferToAcount < listOfBankAccounts.Count)
                {
                    loop2 = false;
                }
                else if (transferToAcount >= listOfBankAccounts.Count)
                {
                    Console.WriteLine("Kontot finns inte i systemet");
                }


            }

            decimal amount = 0;
            bool loop3 = true;
            while (loop3)
            {
                Console.WriteLine("Vilken summa vill du föra över? : ");


                try
                {
                    amount = Convert.ToDecimal(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ogiltligt val");
                }
                if (amount <= 0)
                {
                    Console.WriteLine("Summan måste vara högre än 0");
                }
                else if (amount > listOfBankAccounts[accountChoice].AccountBalance)
                {
                    Console.WriteLine("Du har inte tillräckligt med pengar på konto för att överföra denna summan");
                }
                else if (amount > 0)
                {
                    loop3 = false;
                }
            }

            listOfBankAccounts[accountChoice].AccountBalance = listOfBankAccounts[accountChoice].AccountBalance - amount;
            listOfBankAccounts[transferToAcount].AccountBalance = listOfBankAccounts[transferToAcount].AccountBalance + amount;

            listOfYourAccountTransactions.Add(new Transaction(amount, DateTime.Now, listOfBankAccounts[accountChoice].AccountName, listOfBankAccounts[transferToAcount].AccountName));


            Console.WriteLine("Tryck på enter för att återgå till menyn.");
            Console.ReadKey();
        }

        public void CreateNewAccount()
        {
            Console.Clear();
            Console.WriteLine("Vad ska ditt nya konto har för namn? ");
            string newAccountName = Console.ReadLine();
            listOfBankAccounts.Add(new BankAccounts(newAccountName, 0));
            listOfAddedAccounts.Add(new Transaction(0, DateTime.Now, listOfBankAccounts[listOfBankAccounts.Count-1].AccountName, ""));

            Console.WriteLine("Tryck på enter för att återgå till menyn.");
            Console.ReadKey();
        }


        public void RemoveExistingAccount()
        {

            Console.Clear();
            int choosenAccount = 0;
            bool loop = true;
            while (loop == true)
            {
                
                for (int i = 0; i < listOfBankAccounts.Count; i++)
                {
                    Console.Write(i + " --- ");
                    Console.Write(listOfBankAccounts[i].AccountName);
                    Console.Write(" --- ");
                    Console.Write(listOfBankAccounts[i].AccountBalance);
                    Console.WriteLine();
                    Console.WriteLine();
                }
                Console.WriteLine("Välj det kontot du vill ta bort");
                choosenAccount = Convert.ToInt32(Console.ReadLine());




                if (choosenAccount >= listOfBankAccounts.Count)
                {
                    Console.WriteLine("Det kontot finns inte i systemet");


                }
                else if (listOfBankAccounts[choosenAccount].AccountBalance > 0)
                {
                    Console.WriteLine("Du kan inte ta bort ett konto som innehåller pengar.");
                }
                else if (listOfBankAccounts.Count < 2)
                {
                    Console.WriteLine("Du måste ha minst ett konto i banken! Du kommer nu att återgå till menyn istället.");
                    loop = false;
                }
                else if (choosenAccount < listOfBankAccounts.Count && listOfBankAccounts[choosenAccount].AccountBalance <= 0)
                {
                    listOfRemovedAccounts.Add(new Transaction(0, DateTime.Now, listOfBankAccounts[choosenAccount].AccountName, ""));
                    Console.WriteLine("Du tog bort kontot som hette " + listOfBankAccounts[choosenAccount].AccountName);
                    loop = false;
                    listOfBankAccounts.RemoveAt(choosenAccount);
                }
            }

            

            Console.WriteLine("Tryck på enter för att återgå till menyn.");
            Console.ReadKey();
        }

        public void TransferMoneyToAnotherCustomer(List<Customer> listOfCustomers, int loggedInUserIndex)
        {
            Console.Clear();
            bool loop = true;
            int transferMoneyToThisCustomerIndex = 0;
            while (loop == true)
            {
                Console.WriteLine("Till vilken användare vill du skicka pengar till? Mata in användarnamnet på den användare som du vill skicka pengar till.");
                string transferToAnotherCustomer = Console.ReadLine();

                foreach (Customer customer in listOfCustomers)
                {
                    if (transferToAnotherCustomer == customer.UserName)
                    {
                        if ((transferToAnotherCustomer == listOfCustomers[loggedInUserIndex].UserName))
                        {
                            Console.WriteLine("Du kan inte mata in ditt egna användarnamn! Försök igen!");
                        }
                        else
                        {
                            transferMoneyToThisCustomerIndex = listOfCustomers.IndexOf(customer);
                            loop = false;
                        }
                    }
                }
                if (loop == true && transferToAnotherCustomer != listOfCustomers[loggedInUserIndex].UserName)
                {
                    Console.WriteLine("Det användarnamnet finns inte i systemet! Försök igen.");
                }
            }

            Console.Clear();
            loop = true;
            int accountChoice = 0;
            while (loop)
            {
                for (int i = 0; i < listOfBankAccounts.Count; i++)
                {
                    Console.Write(i + " --- ");
                    Console.Write(listOfBankAccounts[i].AccountName);
                    Console.Write(" --- ");
                    Console.Write(listOfBankAccounts[i].AccountBalance);
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.WriteLine("Välj vilket konto du vill föra över pengar ifrån:");
                try
                {
                    accountChoice = Convert.ToInt32(Console.ReadLine());
                }

                catch
                {
                    Console.WriteLine("Ogiltligt val");
                }

                if (accountChoice < listOfBankAccounts.Count)
                {
                    loop = false;
                }
                else if (accountChoice >= listOfBankAccounts.Count)
                {
                    Console.WriteLine("Kontot finns inte i systemet");
                }
            }

            decimal amount = 0;
            bool loop3 = true;
            while (loop3)
            {
                Console.WriteLine("Vilken summa vill du föra över? : ");


                try
                {
                    amount = Convert.ToDecimal(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ogiltligt val");
                }
                if (amount <= 0)
                {
                    Console.WriteLine("Summan måste vara högre än 0");
                }
                else if (amount > listOfBankAccounts[accountChoice].AccountBalance)
                {
                    Console.WriteLine("Du har inte tillräckligt med pengar på konto för att överföra denna summan");
                }
                else if (amount > 0)
                {
                    loop3 = false;
                }
            }

            listOfBankAccounts[accountChoice].AccountBalance = listOfBankAccounts[accountChoice].AccountBalance - amount;
            listOfCustomers[transferMoneyToThisCustomerIndex].listOfBankAccounts[0].AccountBalance = listOfCustomers[transferMoneyToThisCustomerIndex].listOfBankAccounts[0].AccountBalance + amount;

            listOfTransactionsToOtherCustomers.Add(new Transaction(amount, DateTime.Now, listOfBankAccounts[accountChoice].AccountName, listOfCustomers[transferMoneyToThisCustomerIndex].UserName));


            Console.WriteLine("Tryck på enter för att återgå till menyn.");
            Console.ReadKey();


        }

        public void PrintTransactionHistory()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("För att se transaktioner mellan dina konton tryck 1");
                Console.WriteLine("För att se transaktioner från dina konton till andra användare tryck 2");
                Console.WriteLine("För att se borttagna konton tryck 3");
                Console.WriteLine("För att se tillagda konton tryck 4");
                Console.WriteLine("För att gå tillbaka till huvudmenyn tryck 5");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        for (int i = 0; i < listOfYourAccountTransactions.Count; i++)
                        {
                            
                            Console.Write(listOfYourAccountTransactions[i].Date);
                            Console.Write(" --- ");
                            Console.Write($"Du har överfört: {listOfYourAccountTransactions[i].AmountTransaction} Från konto: {listOfYourAccountTransactions[i].AccountName}. Till konto: {listOfYourAccountTransactions[i].AccountName2} ");
                            Console.WriteLine();
                            Console.WriteLine();

                        }
                        Console.WriteLine();
                        Console.WriteLine("Tryck på enter för att gå tillbaka till menyn");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        for (int i = 0; i < listOfTransactionsToOtherCustomers.Count; i++)
                        {
                            
                            Console.Write(listOfTransactionsToOtherCustomers[i].Date);
                            Console.Write(" --- ");
                            Console.Write($"Du har överfört: {listOfTransactionsToOtherCustomers[i].AmountTransaction} Från konto: {listOfTransactionsToOtherCustomers[i].AccountName}. Till användare: {listOfTransactionsToOtherCustomers[i].AccountName2} ");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Tryck på enter för att gå tillbaka till menyn");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        for (int i = 0; i < listOfRemovedAccounts.Count; i++)
                        {

                            Console.Write(listOfRemovedAccounts[i].Date);
                            Console.Write(" --- ");
                            Console.Write($"Du har tagit bort konto: {listOfRemovedAccounts[i].AccountName}");
                            Console.WriteLine();
                            Console.WriteLine();

                        }
                        Console.WriteLine();
                        Console.WriteLine("Tryck på enter för att gå tillbaka till menyn");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Clear();
                        for (int i = 0; i < listOfAddedAccounts.Count; i++)
                        {

                            Console.Write(listOfAddedAccounts[i].Date);
                            Console.Write(" --- ");
                            Console.Write($"Du har lagt till konto: {listOfAddedAccounts[i].AccountName}");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Tryck på enter för att gå tillbaka till menyn");
                        Console.ReadKey();
                        break;

                    case "5":
                        loop = false;
                        break;

                    default:
                        break;

                }



            }



        }

    }
}