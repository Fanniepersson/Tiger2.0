using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Tiger_2._0
{
    public class Users : BankUsers
    {
        public List<BankAccounts> listOfBankAccounts = new List<BankAccounts>();
        public void PrintBankAccounts() // Denna metoden rör vanliga kunder.
        {
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
        
        public void CreateNewAdmin(List<Users> listOfUsers) // Denna metoden rör admins.
        {
            string nameForNewAdmin = " ";
            bool userNameAlreadyExists = true;
            while (userNameAlreadyExists == true)
            {
                Console.WriteLine("Vad ska den nya administratören ha för användarnamn?");
                nameForNewAdmin = Console.ReadLine();

                bool nameAlreadyTaken = false;

                foreach (Users user in listOfUsers)
                {
                    if (user.UserName == nameForNewAdmin)
                    {
                        Console.WriteLine("Det namnet finns redan i systemet, välj ett annat!");
                        nameAlreadyTaken = true;
                    }
                }
                if (nameAlreadyTaken == false)
                {
                    userNameAlreadyExists = false;
                }
            }

            bool pinCodeConsistsOfSixNumbers = false;
            while (pinCodeConsistsOfSixNumbers == false)
            {
                Console.WriteLine("Välj nu en pinkod för den nya administratören.");
                int pinCodeForNewAdmin = Convert.ToInt32(Console.ReadLine());
                string stringPinCodeForNewAdmin = Convert.ToString(pinCodeForNewAdmin);

                if (stringPinCodeForNewAdmin.Length == "123456".Length)
                {
                    listOfUsers.Add(new Users // Denna algoritm används för att skapa en ny administratör.
                    {
                        UserName = nameForNewAdmin,
                        PinCode = pinCodeForNewAdmin,
                        AdminPrivileges = true
                    });
                    pinCodeConsistsOfSixNumbers = true;
                }
                else
                {
                    Console.WriteLine("Din pinkod måste innehålla 6 stycken siffror!");
                }
            }

            Console.WriteLine("Tryck på enter för att återgå till menyn.");
            Console.ReadKey();
        }

        public void TransferMoneyToAnotherAccount()
        {
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


        }

        public void CreateNewAccount()
        {
            Console.WriteLine("Vad ska ditt nya konto har för namn? ");
            string newAccountName = Console.ReadLine();
            listOfBankAccounts.Add(new BankAccounts(newAccountName, 0));

        }
    }
}
