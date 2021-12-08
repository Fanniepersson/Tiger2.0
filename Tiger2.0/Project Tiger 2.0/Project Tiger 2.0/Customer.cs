using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Tiger_2._0
{
    public class Customer : Users
    {
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
                Console.WriteLine("3 --- Överför dina pengar till en annan användare. (inte implementerad ännu)");
                Console.WriteLine("4 --- Öppna upp ett nytt konto.");
                Console.WriteLine("5 --- Avsluta ett existerande konto.");
                Console.WriteLine("6 --- Logga ut.");

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

                        break;

                    case "4":
                        listOfCustomers[loggedInUserIndex].CreateNewAccount();
                        break;

                    case "5":
                        listOfCustomers[loggedInUserIndex].RemoveExistingAccount();
                        break;

                    case "6":
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

            Console.WriteLine("Tryck på enter för att återgå till menyn.");
            Console.ReadKey();
        }

        public void CreateNewAccount()
        {
            Console.Clear();
            Console.WriteLine("Vad ska ditt nya konto har för namn? ");
            string newAccountName = Console.ReadLine();
            listOfBankAccounts.Add(new BankAccounts(newAccountName, 0));

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
                //Console.WriteLine("Välj det kontot du vill ta bort");
                //int choosenAccount = Convert.ToInt32(Console.ReadLine());

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
                else if (choosenAccount < listOfBankAccounts.Count && listOfBankAccounts[choosenAccount].AccountBalance <= 0) 
                {
                    loop = false;
                    Console.WriteLine("Du tog bort kontot som hette " + listOfBankAccounts[choosenAccount].AccountName);
                }
               else if (listOfBankAccounts[choosenAccount].AccountBalance > 0)
               {
                    Console.WriteLine("Du kan inte ta bort ett konto som innehåller pengar.");
               }
            }

            listOfBankAccounts.RemoveAt(choosenAccount);
            
           



            Console.WriteLine("Tryck på enter för att återgå till menyn.");
            Console.ReadKey();

        }
    }
}
