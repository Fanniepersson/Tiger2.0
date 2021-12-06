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
    }
}
